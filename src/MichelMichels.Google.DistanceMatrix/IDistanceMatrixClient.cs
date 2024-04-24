using MichelMichels.Google.DistanceMatrix.Models;

namespace MichelMichels.Google.DistanceMatrix;

public interface IDistanceMatrixClient
{
    Task<int> GetMetersBetweenPlaces(string origin, string destination);
    Task<int> GetSecondsBetweenPlaces(string origin, string destination);

    Task<DistanceMatrixResponse> GetDistanceMatrixReponse(DistanceMatrixRequest request);
}