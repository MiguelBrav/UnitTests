namespace UnitTests.InitialProject.TestExercise.Factory;

public class HashFactory
{
    public static HashProduct CreateHashAlgorithm(string algorithmName)
    {
        return algorithmName.ToUpper() switch
        {
            "MD5" => new MD5Hash(),
            "SHA256" => new SHA256Hash(),
            "HMACSHA256" => new HMACSHA256Hash(),
            _ => throw new ArgumentException("Not supported")
        };
    }
}
