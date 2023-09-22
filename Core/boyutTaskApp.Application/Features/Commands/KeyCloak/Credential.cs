using System.Text.Json.Serialization;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.KeyCloak;

public class Credential
{
    public string Type { get; set; }
    public string Value { get; set; }
    public bool Temporary { get; set; }
}