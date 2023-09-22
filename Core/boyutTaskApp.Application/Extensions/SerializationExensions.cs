using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace boyutTaskAppAPI.Applicaton.Extensions;

public static class SerializationExtensions
{
    /// <summary>
    /// <para>Serializes the object into a Json string.</para>
    /// <para>
    /// <b>WARNING! This method has a default behavior as listed below:</b>
    /// <ul>
    /// <li>Ignores cycles</li>
    /// <li>Uses camelCase naming convention for both properties dictionary keys</li>
    /// <li>Ignores null values by default</li>
    /// <li>Outputs a flat output without any indentation by default.</li>
    /// </ul>
    /// These behaviors can be changed by optional parameters.
    /// </para>
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="indented">Outputs multiline with indented json when true. Default
    /// is false.</param>
    /// <param name="ignoreNulls">When set, the output will not contain properties
    /// which has null value. Default is true.</param>
    /// <returns>Serialized string.</returns>
    public static string ToJson(this object obj,
        bool indented = false,
        bool ignoreNulls = true)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions
        {
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            AllowTrailingCommas = false,
            DefaultIgnoreCondition = ignoreNulls
                ? JsonIgnoreCondition.WhenWritingNull
                : JsonIgnoreCondition.Never,
            WriteIndented = indented,
        });
    }

    // Encode a string to use in a URL, but use %20 for spaces, instead of +
    public static string UrlEncode(this string str)
    {
        return WebUtility.UrlEncode(str ?? "").Replace("+", "%20");
    }

    /// <summary>
    /// <para>Deserializes a string into an object of given type T.</para>
    /// </summary>
    /// <param name="jsonString"></param>
    /// <param name="throwExceptions">When false, the method will suppress any
    /// deserialization exception. Default is true, which will allow exceptions
    /// to be thrown.</param>
    /// <param name="caseInsensitive">When set to false, the method will expect
    /// to match camelCase properties with the ones in the target class. Default
    /// is true and will allow any casing of the property names to be matched.
    /// </param>
    /// <typeparam name="T">Target object's type name.</typeparam>
    /// <returns>Object instance of type T.</returns>
    /// <exception cref="Exception">An exception with the original deserialization
    /// exception in InnerException.</exception>
    public static T? FromJson<T>(this string jsonString,
        bool throwExceptions = true,
        bool caseInsensitive = true)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(jsonString,
                new JsonSerializerOptions
                {
                    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = caseInsensitive,
                    AllowTrailingCommas = true,
                });
        }
        catch (System.Exception ex)
        {
            if (throwExceptions)
                throw new System.Exception("ConvertFromJsonFiled", ex);

            return default;
        }
    }

    /// <summary>
    /// <para>Deserializes a string into an object of given destination type.</para>
    /// </summary>
    /// <param name="jsonString">JSON string representation of object</param>
    /// <param name="destinationType">Type to deserialize to</param>
    /// <returns>"destinationType" instance</returns>
    public static object? FromJson(this string jsonString, Type destinationType)
    {
        return JsonSerializer.Deserialize(jsonString, destinationType, new JsonSerializerOptions
        {
            DictionaryKeyPolicy =
                JsonNamingPolicy.CamelCase,
            PropertyNamingPolicy =
                JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = false,
        });
    }
}