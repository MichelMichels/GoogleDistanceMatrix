using MichelMichels.Google.DistanceMatrix.Models;
using System.Net.Http.Json;

namespace MichelMichels.Google.DistanceMatrix;

public class DistanceMatrixClient(string apiKey) : IDistanceMatrixClient
{
    private const string baseUrl = @"https://maps.googleapis.com/maps/api/distancematrix/";

    private readonly string apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
    private readonly Dictionary<string, DistanceMatrixResponse> cache = [];

    private HttpClient? _httpClient;

    /// <summary>
    /// Gets the distance between origin and destination
    /// </summary>
    /// <param name="origin">The place of origin</param>
    /// <param name="destination">The place of destination</param>
    /// <returns>Distance in meters</returns>
    public async Task<int> GetMetersBetweenPlaces(string origin, string destination)
    {
        DistanceMatrixRequest request = new()
        {
            Origins = origin,
            Destinations = destination,
            Key = apiKey,
        };

        DistanceMatrixResponse response = await GetDistanceMatrixReponse(request);
        Element? firstElement = GetFirstElementFromResponse(response);
        if (firstElement is not null)
        {
            return firstElement.Distance?.Value ?? 0;
        }

        return 0;
    }

    /// <summary>
    /// Gets the duration in seconds of the journey between origin and destination.
    /// </summary>
    /// <param name="origin">The place of origin</param>
    /// <param name="destination">The place of destination</param>
    /// <returns>Duration in seconds</returns>
    public async Task<int> GetSecondsBetweenPlaces(string origin, string destination)
    {
        DistanceMatrixRequest request = new()
        {
            Origins = origin,
            Destinations = destination,
            Key = apiKey,
        };

        DistanceMatrixResponse response = await GetDistanceMatrixReponse(request);
        Element? firstElement = GetFirstElementFromResponse(response);
        if (firstElement is not null)
        {
            return firstElement.Duration?.Value ?? 0;
        }

        return 0;
    }

    public async Task<DistanceMatrixResponse> GetDistanceMatrixReponse(DistanceMatrixRequest request)
    {
        string format = "json";
        string requestUri = $"{format}?{request}";
        if (cache.TryGetValue(requestUri, out DistanceMatrixResponse? value))
        {
            return value;
        }

        HttpClient client = GetOrCreateHttpClient();
        HttpResponseMessage message = await client.GetAsync(requestUri);

        DistanceMatrixResponse response = await message.Content.ReadFromJsonAsync<DistanceMatrixResponse>() ?? throw new NotSupportedException();
        cache.Add(requestUri, response);

        return response;
    }

    private HttpClient GetOrCreateHttpClient()
    {
        return _httpClient ??= new HttpClient()
        {
            BaseAddress = new Uri(baseUrl)
        };
    }
    private static Element? GetFirstElementFromResponse(DistanceMatrixResponse response)
    {
        Row? firstRow = response.Rows.FirstOrDefault();
        if (firstRow is not null)
        {
            return firstRow.Elements.FirstOrDefault();
        }

        return null;
    }
}
