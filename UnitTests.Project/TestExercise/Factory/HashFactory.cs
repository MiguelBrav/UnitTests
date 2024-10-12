namespace UnitTests.InitialProject.TestExercise.Factory
{
    public class HashFactory
    {
        public static HashProduct CreateHashAlgorithm(string algorithmName)
        {
            return algorithmName.ToUpper() switch
            {
                "MD5" => new MD5Hash(),
                _ => throw new ArgumentException("Not supported")
            };
        }
    }
}
