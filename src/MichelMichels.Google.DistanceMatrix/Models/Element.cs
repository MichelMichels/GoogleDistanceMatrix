using System.Text.Json.Serialization;

namespace MichelMichels.Google.DistanceMatrix.Models;

public class Element
{
    [JsonPropertyName("distance")]
    public Distance? Distance { get; set; }

    [JsonPropertyName("duration")]
    public Duration? Duration { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
}
