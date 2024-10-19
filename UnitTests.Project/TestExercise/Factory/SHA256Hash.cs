using System.Security.Cryptography;
using System.Text;

namespace UnitTests.InitialProject.TestExercise.Factory;

public class SHA256Hash : HashProduct
{
    public override string Hash(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    public override bool Verify(string input, string hash)
    {
        return Hash(input) == hash;
    }
}