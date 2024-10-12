namespace UnitTests.InitialProject.TestExercise.Factory;

public abstract class HashCreator
{
    public abstract HashProduct CreateHashAlgorithm();

    public string HashInput(string input)
    {
        HashProduct hashAlgorithm = CreateHashAlgorithm();
        return hashAlgorithm.Hash(input);
    }

    public bool VerifyHash(string input, string hash)
    {
        HashProduct hashAlgorithm = CreateHashAlgorithm();
        return hashAlgorithm.Verify(input, hash);
    }
}
