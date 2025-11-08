#  UnitTests Repository  
### Unit Testing and Usage Examples in **xUnit**, **NUnit**, and **MSTest**

This repository demonstrates how to write, organize, and execute **unit tests** using three of the most popular .NET testing frameworks:  
-  **xUnit**
-  **NUnit**
-  **MSTest**

Each example shows how to test different kinds of classes, such as string utilities, mathematical operations, hashing factories, and classes using dependency injection with **Moq**.

---

## Setup Instructions

### 1. Clone Repository
```bash
git clone https://github.com/MiguelBrav/UnitTests.git
cd UnitTests
```

## Frameworks comparation

| Feature                   | xUnit                           | NUnit                              | MSTest                             |
| ------------------------- | ------------------------------- | ---------------------------------- | ---------------------------------- |
| Attribute for test method | `[Fact]` / `[Theory]`           | `[Test]` / `[TestCase]`            | `[TestMethod]` / `[DataRow]`       |
| Setup method              | Constructor / `[IClassFixture]` | `[SetUp]`                          | `[TestInitialize]`                 |
| Teardown method           | `IDisposable.Dispose()`         | `[TearDown]`                       | `[TestCleanup]`                    |
| Assertions                | `Assert.Equal`, `Assert.True`   | `Assert.AreEqual`, `Assert.IsTrue` | `Assert.AreEqual`, `Assert.IsTrue` |
| Parameterized tests       | `[Theory] + [InlineData]`       | `[TestCase]`                       | `[DataRow]`                        |
| Mocking support           | via `Moq`                       | via `Moq`                          | via `Moq`                          |

## Key Takeaways
- xUnit encourages cleaner, constructor-based setup.
- NUnit is highly expressive with attributes like [SetUp], [TearDown], and [TestCase].
- MSTest integrates deeply with Visual Studio and enterprise tools.
- Moq is a powerful mocking framework that supports return values, ref/out parameters, callbacks, and property verification.

  ## Versioning

Updated from .NET 6 to .NET 8 

## Package References

All NuGet packages updated to compatible .NET 8 versions. 

## Feedback

If you have any feedback, please reach out to me.

