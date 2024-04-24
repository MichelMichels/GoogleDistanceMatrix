using MichelMichels.Google.DistanceMatrix.Enums;
using MichelMichels.Google.DistanceMatrix.Exceptions;
using MichelMichels.Google.DistanceMatrix.Extensions;

namespace MichelMichels.Google.DistanceMatrix.Models;

public class DistanceMatrixRequest
{
    private readonly Dictionary<string, string> parameterNames = new()
    {
        { "Origins",                    "origins" },
        { "Destinations",               "destinations" },
        { "Key",                        "key" },
        { "Mode",                       "mode" },
        { "Language",                   "language" },
        { "Region",                     "region" },
        { "Avoid",                      "avoid" },
        { "Units",                      "units" },
        { "ArrivalTime",                "arrival_time" },
        { "DepartureTime",              "departure_time" },
        { "TrafficModel",               "traffic_model" },
        { "TransitMode",                "transit_mode" },
        { "TransitRoutingPreference",   "transit_routing_preference" },
    };

    // Required
    public string Origins { get; set; } = string.Empty;
    public string Destinations { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;

    // Optional
    public TravelMode Mode { get; set; } = TravelMode.Driving;
    public string Language { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Avoid { get; set; } = string.Empty;
    public string Units { get; set; } = string.Empty;
    public DateTime ArrivalTime { get; set; } = DateTime.Today;
    public DateTime DepartureTime { get; set; } = DateTime.Today;
    public TrafficModel TrafficModel { get; set; } = TrafficModel.BestGuess;
    public TransitMode TransitMode { get; set; } = TransitMode.Bus;
    public TransitRoutingPreference TransitRoutingPreference { get; set; } = TransitRoutingPreference.LessWalking;

    public override string ToString()
    {
        if (Origins.IsEmpty())
            throw new MissingParameterException(nameof(Origins));

        if (Destinations.IsEmpty())
            throw new MissingParameterException(nameof(Destinations));

        if (Key.IsEmpty())
            throw new MissingParameterException(nameof(Key));

        return $"{parameterNames[nameof(Origins)]}={Origins}&{parameterNames[nameof(Destinations)]}={Destinations}&{parameterNames[nameof(Key)]}={Key}";
    }
}
