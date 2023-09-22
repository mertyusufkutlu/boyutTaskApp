using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace boyutTaskAppAPI.Applicaton.Base;

public class BaseException : System.Exception
{
    public int StatusCode { get; set; }

    public BaseException()
    {
    }

    protected BaseException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(
        serializationInfo, streamingContext)
    {

    }

    public BaseException(string message, int statusCode = StatusCodes.Status500InternalServerError) : base(message)
    {
        StatusCode = statusCode;
    }

    public BaseException(string message, System.Exception? inner,
        int statusCode = StatusCodes.Status500InternalServerError) : base(message, inner)
    {
        StatusCode = statusCode;
    }
}