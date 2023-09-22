using System.Text;

namespace boyutTaskAppAPI.Applicaton.Extensions;

public static class JsonContentExtensions
{
    public static StringContent MakeJsonContent(this object obj)
    {
        return new StringContent(obj.ToJson(), Encoding.UTF8, "application/json");
    }
}