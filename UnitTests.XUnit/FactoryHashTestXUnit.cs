using UnitTests.InitialProject.TestExercise.Factory;
using Xunit;

namespace UnitTests.XUnit;

public class FactoryHashTestXUnit
{
    [Theory] 
    [InlineData("password123")] 
    [InlineData("mySecurePassword")]
    [InlineData("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidMD5Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("MD5");

        // Act
        string hash = hashAlgorithm.Hash(input);

        // Assert
        Assert.NotNull(hash); 
        Assert.IsType<string>(hash);
        Assert.NotEmpty(hash); 
    }

    [Theory]
    [InlineData("password123")]
    [InlineData("mySecurePassword")]
    [InlineData("testInput")]
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidMD5Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("MD5");

        // Act
        string hash = hashAlgorithm.Hash(input);
        bool isValid = hashAlgorithm.Verify(input, hash);

        // Assert
        Assert.True(isValid);
        Assert.IsType<bool>(isValid); 
    }

    [Theory]
    [InlineData("password123", "InvalidHashValue")]
    [InlineData("mySecurePassword", "SomeOtherInvalidHash")]
    [InlineData("testInput", "AnotherInvalidHashValue")]
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidMD5Hash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("MD5");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.False(isValid);
        Assert.IsType<bool>(isValid);
    }

    [Theory]
    [InlineData("password123")]
    [InlineData("mySecurePassword")]
    [InlineData("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("SHA256");

        // Act
        string hash = hashAlgorithm.Hash(input);

        // Assert
        Assert.NotNull(hash);
        Assert.IsType<string>(hash);
        Assert.NotEmpty(hash);
    }

    [Theory]
    [InlineData("password123")]
    [InlineData("mySecurePassword")]
    [InlineData("testInput")]
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("SHA256");

        // Act
        string hash = hashAlgorithm.Hash(input);
        bool isValid = hashAlgorithm.Verify(input, hash);

        // Assert
        Assert.True(isValid);
        Assert.IsType<bool>(isValid);
    }

    [Theory]
    [InlineData("password123", "InvalidHashValue")]
    [InlineData("mySecurePassword", "SomeOtherInvalidHash")]
    [InlineData("testInput", "AnotherInvalidHashValue")]
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidSHA256Hash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("SHA256");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.False(isValid);
        Assert.IsType<bool>(isValid);
    }

    [Theory]
    [InlineData("password123")]
    [InlineData("mySecurePassword")]
    [InlineData("testInput")]
    public void HashAlgorithmFactory_ShouldReturnValidHMACSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("HMACSHA256");

        // Act
        string hash = hashAlgorithm.Hash(input);

        // Assert
        Assert.NotNull(hash);
        Assert.IsType<string>(hash);
        Assert.NotEmpty(hash);
    }

    [Theory]
    [InlineData("password123")]
    [InlineData("mySecurePassword")]
    [InlineData("testInput")]
    public void HashAlgorithmFactory_Verify_ShouldReturnTrueForValidHMACSHA256Hash(string input)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("HMACSHA256");

        // Act
        string hash = hashAlgorithm.Hash(input);
        bool isValid = hashAlgorithm.Verify(input, hash);

        // Assert
        Assert.True(isValid);
        Assert.IsType<bool>(isValid);
    }

    [Theory]
    [InlineData("password123", "InvalidHashValue")]
    [InlineData("mySecurePassword", "SomeOtherInvalidHash")]
    [InlineData("testInput", "AnotherInvalidHashValue")]
    public void HashAlgorithmFactory_Verify_ShouldReturnFalseForInvalidHMACSHA256Hash(string input, string incorrectHash)
    {
        // Arrange
        HashProduct hashAlgorithm = HashFactory.CreateHashAlgorithm("HMACSHA256");

        // Act
        bool isValid = hashAlgorithm.Verify(input, incorrectHash);

        // Assert
        Assert.False(isValid);
        Assert.IsType<bool>(isValid);
    }
}
