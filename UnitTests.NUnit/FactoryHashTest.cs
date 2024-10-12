using NUnit.Framework;
using UnitTests.InitialProject.TestExercise.Factory;

namespace UnitTests.NUnit;

[TestFixture] 
public class FactoryHashTest
{
    [Test]
    [TestCase("password123")]
    [TestCase("mySecurePassword")]
    [TestCase("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidMD5Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("MD5");

        // Act
        string hash = hashAlgorithm.Hash(input);

        // Assert
        Assert.IsNotNull(hash);
        Assert.IsInstanceOf<string>(hash); // Equivalente a Assert.IsInstanceOfType en MSTest
        Assert.IsNotEmpty(hash); // En NUnit, para verificar que un string no esté vacío
    }

    [Test]
    [TestCase("password123")]
    [TestCase("mySecurePassword")]
    [TestCase("testInput")]
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidMD5Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("MD5");

        // Act
        string hash = hashAlgorithm.Hash(input);
        bool isValid = hashAlgorithm.Verify(input, hash);

        // Assert
        Assert.IsTrue(isValid);
        Assert.IsInstanceOf<bool>(isValid);
    }

    [Test]
    [TestCase("password123", "InvalidHashValue")]
    [TestCase("mySecurePassword", "SomeOtherInvalidHash")]
    [TestCase("testInput", "AnotherInvalidHashValue")]
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidMD5Hash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("MD5");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsInstanceOf<bool>(isValid); 
    }
}
