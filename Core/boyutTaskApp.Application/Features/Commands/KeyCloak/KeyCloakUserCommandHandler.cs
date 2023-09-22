using MediatR;
using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Extensions;
using boyutTaskAppAPI.Applicaton.Settings;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.KeyCloak
{
    public class KeyCloakUserCommandHandler : IRequestHandler<KeyCloakUserRequest, KeyCloakResponse>,
        IRequestHandler<GetKeyCloakTokenRequest, KeyCloakResponse>
        ,IRequestHandler<KeyCloakUserCreateRequest, bool>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly KeyCloakSettings _keyCloakSettings;
        private readonly IDistributedCache _distributedCache;
        private readonly IMediator _mediator;

        public KeyCloakUserCommandHandler(IHttpClientFactory httpClientFactory, KeyCloakSettings keyCloakSettings,
            IDistributedCache distributedCache, IMediator mediator)
        {
            _httpClientFactory = httpClientFactory;
            _keyCloakSettings = keyCloakSettings;
            _distributedCache = distributedCache;
            _mediator = mediator;
        }

        public async Task<KeyCloakResponse> Handle(KeyCloakUserRequest request, CancellationToken cancellationToken)
        {
            if (request.Password == null)
            {
                throw new BaseException("Password cannot be null", 401);
            }

            var requestBody = new List<KeyValuePair<string, string>>
            {
                new(_keyCloakSettings.UsernameBodyName, request.UserId.ToString()!),
                new(_keyCloakSettings.PasswordBodyName, request.Password),
                new(_keyCloakSettings.ClientIdBodyName, _keyCloakSettings.ClientIdBodyValue),
                new(_keyCloakSettings.GrantTypeBodyName, _keyCloakSettings.GrantTypePasswordBodyValue),
                new(_keyCloakSettings.ClientSecretBodyName, _keyCloakSettings.ClientSecretBodyValue),
                new(_keyCloakSettings.ScopeBodyName, _keyCloakSettings.ScopeBodyValue),
            };

            var content = new FormUrlEncodedContent(requestBody);
            using var httpClient = _httpClientFactory.CreateClient("KeyCloak");
            using var response = await httpClient.PostAsync(_keyCloakSettings.TokenUrl, content, cancellationToken);
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
            var responseObj = responseString.FromJson<KeyCloakResponse>();
            if (response.IsSuccessStatusCode)
            {
                return responseObj;
            }

            throw new BaseException(responseString, 401);
        }

        public async Task<KeyCloakResponse> Handle(GetKeyCloakTokenRequest request, CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateClient("KeyCloak");
            var cachedToken = await _distributedCache.GetStringAsync("KEYCLOAK-TOKEN", token: cancellationToken);
            if (cachedToken != null)
            {
                return cachedToken.FromJson<KeyCloakResponse>();
            }

            var requestBody = new List<KeyValuePair<string, string>>
            {
                new(_keyCloakSettings.UsernameBodyName, _keyCloakSettings.UsernameBodyValue),
                new(_keyCloakSettings.PasswordBodyName, _keyCloakSettings.PasswordBodyValue),
                new(_keyCloakSettings.ClientIdBodyName, _keyCloakSettings.ClientIdBodyValue),
                new(_keyCloakSettings.GrantTypeBodyName, _keyCloakSettings.GrantTypePasswordBodyValue),
                new(_keyCloakSettings.ClientSecretBodyName, _keyCloakSettings.ClientSecretBodyValue)
            };
            httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(),
                _keyCloakSettings.ValidationContentType);
            var content = new FormUrlEncodedContent(requestBody);
            using var response = await httpClient.PostAsync(_keyCloakSettings.TokenUrl, content, cancellationToken);
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
            var responseObj = responseString.FromJson<KeyCloakResponse>();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new BaseException("KeyCloakFailedToken");
            }

            await _distributedCache.SetStringAsync("KEYCLOAK-TOKEN",
                responseString,
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(6)
                },
                token: cancellationToken);
            return responseObj;
        }

        public async Task<bool> Handle(KeyCloakUserCreateRequest keyCloakUserCreateRequest,
            CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateClient("KeyCloak");
            var token = await _mediator.Send(new GetKeyCloakTokenRequest(), cancellationToken);

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token?.AccessToken);

            object keycloakRequest = new
            {
                username = keyCloakUserCreateRequest.UserId.ToString(),
                email = keyCloakUserCreateRequest.Email,
                enabled = true,
                credentials = new List<Credential>
                    { new() { Type = "password", Temporary = false, Value = keyCloakUserCreateRequest.Password } },
            };

            var content = keycloakRequest.MakeJsonContent();
            using var response = await httpClient.PostAsync(_keyCloakSettings.UserUrl, content, cancellationToken);
            if (response == null)
            {
                throw new BaseException("KeyCloakNullResponse", StatusCodes.Status400BadRequest);
            }

            return response.StatusCode.ToString() switch
            {
                "Conflict" => throw new BaseException("KeyCloakConflictResponse", StatusCodes.Status409Conflict),
                "Created" => true,
                _ => throw new BaseException("KeyCloakForbiddenResponse", StatusCodes.Status400BadRequest)
            };
        }
    }
}