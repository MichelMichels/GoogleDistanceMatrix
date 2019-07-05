using GoogleDistanceMatrix.Enums;
using GoogleDistanceMatrix.Exceptions;
using GoogleDistanceMatrix.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDistanceMatrix.Entities
{
    public class RequestParameters
    {
        private Dictionary<string, string> parameterNames = new Dictionary<string, string>
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

        public RequestParameters()
        {
            Key = string.Empty;
            Origins = string.Empty;
            Destinations = string.Empty;
            Mode = TravelMode.Driving;
            Language = string.Empty;
            Region = string.Empty;
            Avoid = string.Empty;
            Units = string.Empty;
            ArrivalTime = DateTime.Today;
            DepartureTime = DateTime.Today;
            TrafficModel = TrafficModel.BestGuess;
            TransitMode = TransitMode.Bus;
            TransitRoutingPreference = TransitRoutingPreference.LessWalking;
        }

        // Required
        public string Origins { get; set; }
        public string Destinations { get; set; }
        public string Key { get; set; }

        // Optional
        public TravelMode Mode { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public string Avoid { get; set; }
        public string Units { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public TrafficModel TrafficModel { get; set; }
        public TransitMode TransitMode { get; set; }
        public TransitRoutingPreference TransitRoutingPreference { get; set; }

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
}
