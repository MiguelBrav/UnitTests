using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.InitialProject.TestExercise.Factory;

namespace UnitTests.MSTest;

[TestClass]
public class FactoryHashTestMS
{
    [TestMethod]
    [DataRow("password123")]
    [DataRow("mySecurePassword")]
    [DataRow("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidMD5Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("MD5");

        // Act
        string hash = hashAlgorithm.Hash(input);

        // Assert
        Assert.IsNotNull(hash);
        Assert.IsInstanceOfType(hash, typeof(string));
        Assert.IsTrue(hash.Length > 0);
    }

    [TestMethod]
    [DataRow("password123")]
    [DataRow("mySecurePassword")]
    [DataRow("testInput")]
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidMD5Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("MD5");

        // Act
        string hash = hashAlgorithm.Hash(input);
        bool isValid = hashAlgorithm.Verify(input, hash);

        // Assert
        Assert.IsTrue(isValid);
        Assert.IsInstanceOfType(isValid, typeof(bool));
    }

    [TestMethod]
    [DataRow("password123", "InvalidHashValue")]
    [DataRow("mySecurePassword", "SomeOtherInvalidHash")]
    [DataRow("testInput", "AnotherInvalidHashValue")]
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidMD5Hash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("MD5");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsInstanceOfType(isValid, typeof(bool));
    }
}
