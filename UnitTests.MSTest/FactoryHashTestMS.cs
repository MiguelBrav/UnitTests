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

    [TestMethod]
    [DataRow("password123")]
    [DataRow("mySecurePassword")]
    [DataRow("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("SHA256");

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
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("SHA256");

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
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidSHA256Hash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("SHA256");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsInstanceOfType(isValid, typeof(bool));
    }

    [TestMethod]
    [DataRow("password123")]
    [DataRow("mySecurePassword")]
    [DataRow("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidHMACSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("HMACSHA256");

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
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidHMACSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("HMACSHA256");

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
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidHMACSHA256Hash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("HMACSHA256");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsInstanceOfType(isValid, typeof(bool));
    }

    [TestMethod]
    [DataRow("password123")]
    [DataRow("mySecurePassword")]
    [DataRow("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidBCryptHash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("BCRYPT");

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
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidBCryptHash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("BCRYPT");

        // Act
        string hash = hashAlgorithm.Hash(input);
        bool isValid = hashAlgorithm.Verify(input, hash);

        // Assert
        Assert.IsTrue(isValid);
        Assert.IsInstanceOfType(isValid, typeof(bool));
    }

    [TestMethod]
    [DataRow("password123", "$2a$13$uWJ4XRVVcjZaElkjPbcOvO.q/iRJofp6uGy92t9b12h82KtQPXrRa")]
    [DataRow("mySecurePassword", "$2a$13$cZ7abcfATUDppPe9IeYpPuOesEVlw8t9WiPxZiiNXJceehkmXG4ar")]
    [DataRow("testInput", "$2a$13$yq8UF1Ev3GyHb2zzN/zzIuHRl5dqun0lNCyXhESWuUtxh/ZRQ5j6C")]
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidBCryptHash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("BCRYPT");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsInstanceOfType(isValid, typeof(bool));
    }
}
