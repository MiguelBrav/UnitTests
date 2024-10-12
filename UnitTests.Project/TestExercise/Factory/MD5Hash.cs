namespace UnitTests.InitialProject.TestExercise.Factory;

public class MD5Hash : HashProduct
{
    public override string Hash(string input)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    public override bool Verify(string input, string hash)
    {
        return Hash(input) == hash;
    }
}
