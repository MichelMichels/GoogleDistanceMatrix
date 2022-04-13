using GoogleDistanceMatrix.Entities;
using GoogleDistanceMatrix.Enums;

namespace GoogleDistanceMatrix.Clients
{
    public interface IGoogleDistanceMatrixClient
    {
        int GetDistanceBetweenPlaces(string origin, string destination);
        DistanceMatrixResponse GetDistanceMatrixReponse(RequestParameters parameters, OutputFormat outputFormat);
        int GetDurationBetweenPlaces(string origin, string destination);
    }
}