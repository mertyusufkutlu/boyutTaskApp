using Microsoft.AspNetCore.Http;

namespace boyutTaskAppAPI.Applicaton.Base
{
    public class BaseResponse
    {
        private BaseResponse(BaseException baseException)
        {
            ErrorCode = baseException.StatusCode.ToString();
            ErrorMessage = baseException.Message ?? "";
            StatusCode = baseException.StatusCode;
        }

        protected BaseResponse(string errorCode = "",
                                 string errorMessage = "",
                                 int statusCode = 200)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; } = 200;

        public bool IsSuccess => StatusCode >= 200 && StatusCode <= 299;

        public static BaseResponse Fail(int statusCode = 400,
                                             string errorCode = "UnknownError",
                                             string errorMessage = "")
        {
            return new BaseResponse(errorCode, errorMessage, statusCode);
        }


        public static BaseResponse<T> Fail<T>(int statusCode = 400,
                                           string errorCode = "UnknownError",
                                           string errorMessage = "")
        {
            return new BaseResponse<T>(default(T), errorCode, errorMessage, statusCode);
        }


        public static BaseResponse Fail(BaseException baseException)
        {
            return new BaseResponse(baseException);
        }

        /// <summary>
        /// TODO: Might be better to decouple the generic subclass dependency from "BaseResponse" base class
        /// using <a href="https://en.wikipedia.org/wiki/Interface_segregation_principle">interface segregation principle (ISP)</a>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static BaseResponse<T> Success<T>(T obj, int statusCode = StatusCodes.Status200OK) => new(obj, statusCode: statusCode);
        
    }

    public class BaseResponse<T> : BaseResponse
    {
        public BaseResponse(T? result, string errorCode = "", string errorMessage = "", int statusCode = 200)
            : base(errorCode, errorMessage, statusCode)
        {
            Result = result;                                                                           
        }

        public T? Result { get; set; }
    }
}
