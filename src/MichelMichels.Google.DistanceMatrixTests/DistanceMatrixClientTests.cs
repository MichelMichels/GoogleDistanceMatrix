namespace MichelMichels.Google.DistanceMatrix.Tests;

[TestClass()]
public class DistanceMatrixClientTests
{
    [TestMethod()]
    public void Constructor_ApiKey_ArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new DistanceMatrixClient(null!));
    }
}