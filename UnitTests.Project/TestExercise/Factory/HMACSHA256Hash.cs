using System.Security.Cryptography;
using System.Text;

namespace UnitTests.InitialProject.TestExercise.Factory
{
    public class HMACSHA256Hash : HashProduct
    {
        // Example only, this key should be stored securely and not hardcoded
        private readonly string secretKey = "exampleSecretKey";

        public override string Hash(string input)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = hmac.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public override bool Verify(string input, string hash)
        {
            return Hash(input) == hash;
        }
    }
}
