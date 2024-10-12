namespace UnitTests.InitialProject.TestExercise.Factory;

public abstract class HashProduct
{
    public abstract string Hash(string input);
    public abstract bool Verify(string input, string hash);
}
