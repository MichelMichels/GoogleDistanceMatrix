using System.Text.Json.Serialization;

namespace MichelMichels.Google.DistanceMatrix.Models;

public class DistanceMatrixResponse
{
    [JsonPropertyName("destination_addresses")]
    public List<string> DestinationAddresses { get; set; } = [];

    [JsonPropertyName("origin_addresses")]
    public List<string> OriginAddresses { get; set; } = [];

    [JsonPropertyName("rows")]
    public List<Row> Rows { get; set; } = [];

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
}
