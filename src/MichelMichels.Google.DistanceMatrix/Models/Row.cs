
using System.Text.Json.Serialization;

namespace MichelMichels.Google.DistanceMatrix.Models;

public class Row
{
    [JsonPropertyName("elements")]
    public List<Element> Elements { get; set; } = [];
}
