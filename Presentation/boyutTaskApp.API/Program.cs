using Microsoft.OpenApi.Models;
using boyutTaskAppAPI.Applicaton;
using boyutTaskAppAPI.Applicaton.Settings;
using boyutTaskAppAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
var keycloakSettings = configuration.GetSection("KeyCloak").Get<KeyCloakSettings>();
builder.Services.AddSingleton(keycloakSettings);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddPersistenceServices();
// builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
//     policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
//         .AllowAnyHeader()
//         .AllowAnyMethod()
// ));


// Create a CORS policy
builder.Services.AddCors(opt =>
    {
        opt.AddPolicy("AllowAllOrigins",
            b =>
            {
                b.AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyHeader();
            });
    }
);
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSwaggerGen(c =>
//     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//     {
//         In = ParameterLocation.Header,
//         Description = "Insert JWT Token",
//         Name = "Authorization",
//         Type = SecuritySchemeType.Http,
//         BearerFormat = "JWT",
//         Scheme = "bearer"
//     }));
//
// builder.Services.AddSwaggerGen(w => w.AddSecurityRequirement(
//     new OpenApiSecurityRequirement
//     {
//         {
//             new OpenApiSecurityScheme
//             {
//                 Reference = new OpenApiReference
//                 {
//                     Type = ReferenceType.SecurityScheme,
//                     Id = "Bearer"
//                 }
//             },
//             new string[] { }
//         }
//     }
// ));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Story Genius Api", Version = "v1" });
    c.SwaggerDoc("v1-internal", new OpenApiInfo { Title = "Story Genius Api" + " Internal", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Bearer JWT Token: ",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = "bearer",
            Type = ReferenceType.SecurityScheme,
        }
    };

    c.AddSecurityDefinition("bearer", securityScheme);


    // var filePath = Path.Combine(AppContext.BaseDirectory, $"boyutTaskApp.Api.xml");
    // c.IncludeXmlComments(filePath, includeControllerXmlComments: true);
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();