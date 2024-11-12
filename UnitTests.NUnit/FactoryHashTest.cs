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
        Assert.IsInstanceOf<string>(hash); 
        Assert.IsNotEmpty(hash); 
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

    [Test]
    [TestCase("password123")]
    [TestCase("mySecurePassword")]
    [TestCase("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("SHA256");

        // Act
        string hash = hashAlgorithm.Hash(input);

        // Assert
        Assert.IsNotNull(hash);
        Assert.IsInstanceOf<string>(hash);
        Assert.IsNotEmpty(hash);
    }

    [Test]
    [TestCase("password123")]
    [TestCase("mySecurePassword")]
    [TestCase("testInput")]
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("SHA256");

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
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidSHA256Hash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("SHA256");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsInstanceOf<bool>(isValid);
    }

    [Test]
    [TestCase("password123")]
    [TestCase("mySecurePassword")]
    [TestCase("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidHMACSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("HMACSHA256");

        // Act
        string hash = hashAlgorithm.Hash(input);

        // Assert
        Assert.IsNotNull(hash);
        Assert.IsInstanceOf<string>(hash);
        Assert.IsNotEmpty(hash);
    }

    [Test]
    [TestCase("password123")]
    [TestCase("mySecurePassword")]
    [TestCase("testInput")]
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidHMACSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("HMACSHA256");

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
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidHMACSHA256Hash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("HMACSHA256");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsInstanceOf<bool>(isValid);
    }

    [Test]
    [TestCase("password123")]
    [TestCase("mySecurePassword")]
    [TestCase("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidBCryptHash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("BCRYPT");

        // Act
        string hash = hashAlgorithm.Hash(input);

        // Assert
        Assert.IsNotNull(hash);
        Assert.IsInstanceOf<string>(hash);
        Assert.IsTrue(hash.Length > 0);
    }

    [Test]
    [TestCase("password123")]
    [TestCase("mySecurePassword")]
    [TestCase("testInput")]
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidBCryptHash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("BCRYPT");

        // Act
        string hash = hashAlgorithm.Hash(input);
        bool isValid = hashAlgorithm.Verify(input, hash);

        // Assert
        Assert.IsTrue(isValid);
        Assert.IsInstanceOf<bool>(isValid);
    }

    [Test]
    [TestCase("password123", "$2a$13$uWJ4XRVVcjZaElkjPbcOvO.q/iRJofp6uGy92t9b12h82KtQPXrRa")]
    [TestCase("mySecurePassword", "$2a$13$cZ7abcfATUDppPe9IeYpPuOesEVlw8t9WiPxZiiNXJceehkmXG4ar")]
    [TestCase("testInput", "$2a$13$yq8UF1Ev3GyHb2zzN/zzIuHRl5dqun0lNCyXhESWuUtxh/ZRQ5j6C")]
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidBCryptHash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("BCRYPT");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsInstanceOf<bool>(isValid);
    }
}
