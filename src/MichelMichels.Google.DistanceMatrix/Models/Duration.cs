using System.Text.Json.Serialization;

namespace MichelMichels.Google.DistanceMatrix.Models;

public class Duration
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public int Value { get; set; }
}
