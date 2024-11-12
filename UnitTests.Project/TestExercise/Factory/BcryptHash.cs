namespace UnitTests.InitialProject.TestExercise.Factory;

public class BCryptHash : HashProduct
{
    public override string Hash(string input)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(input,13);
    }

    public override bool Verify(string input, string hash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(input, hash);
    }
}