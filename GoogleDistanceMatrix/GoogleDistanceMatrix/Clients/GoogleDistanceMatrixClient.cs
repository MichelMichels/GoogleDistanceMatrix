using System;
using System.Collections.Generic;
using System.Linq;
using GoogleDistanceMatrix.Entities;
using GoogleDistanceMatrix.Enums;
using RestApiWrapper.Core;
using RestSharp;

namespace GoogleDistanceMatrix.Clients
{

    public class GoogleDistanceMatrixClient : RestApiClient
    {
        private const string baseUrl = @"https://maps.googleapis.com/maps/api/distancematrix/";
        private Dictionary<string, DistanceMatrixResponse> cache;
        private string key;

        public GoogleDistanceMatrixClient(string key) : base(baseUrl)
        {
            this.key = key;
            cache = new Dictionary<string, DistanceMatrixResponse>();
        }

        /// <summary>
        /// Gets the distance between origin and destination
        /// </summary>
        /// <param name="origin">The place of origin</param>
        /// <param name="destination">The place of destination</param>
        /// <returns>Distance in meters</returns>
        public int GetDistanceBetweenPlaces(string origin, string destination)
        {
            var parameters = new RequestParameters()
            {
                Origins = origin,
                Destinations = destination,
                Key = key,
            };

            var response = GetDistanceMatrixReponse(parameters, OutputFormat.JSON);
            if(response.Rows.Count > 0)
            {
                return response.Rows.First().Elements.First().Distance.Value;
            } else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the duration in seconds of the journey between origin and destination.
        /// </summary>
        /// <param name="origin">The place of origin</param>
        /// <param name="destination">The place of destination</param>
        /// <returns>Duration in seconds</returns>
        public int GetDurationBetweenPlaces(string origin, string destination)
        {
            var parameters = new RequestParameters()
            {
                Origins = origin,
                Destinations = destination,
                Key = key,
            };

            var response = GetDistanceMatrixReponse(parameters, OutputFormat.JSON);
            if (response.Rows.Count > 0)
            {
                return response.Rows.First().Elements.First().Duration.Value;
            }
            else
            {
                return 0;
            }
        }

        public DistanceMatrixResponse GetDistanceMatrixReponse(RequestParameters parameters, OutputFormat outputFormat)
        {
            var format = GetOutputFormatString(outputFormat);
            var url = $"{format}?{parameters.ToString()}";
            if(cache.ContainsKey(url))
            {
                return cache[url];
            } else
            {
                var request = GetRequest(url, Method.GET);
                var response = GetResponse<DistanceMatrixResponse>(request).Data;
                cache.Add(url, response);
                return response;
            }
        }

        private string GetOutputFormatString(OutputFormat outputFormat)
        {
            switch (outputFormat)
            {
                case OutputFormat.JSON:
                    return "json";
                case OutputFormat.XML:
                    return "xml";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
