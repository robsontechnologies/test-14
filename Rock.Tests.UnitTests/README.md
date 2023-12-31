# Testing in Rock

The Rock test projects cover a number of different testing scenarios, namely:
1. Unit Tests
The Rock.Tests.UnitTests project contains tests that cover the fundamentals of the Rock codebase.
These tests are designed to verify the behavior of small and isolated pieces of code that are the fundamental building blocks of the Rock application.
Unit tests should be self-contained - they should not depend on any resources that are external to the Rock codebase, such as third-party applications or services, and network or database access.
Unit tests should also be independent of one another - that is, the order in which the tests are executed should not affect the result.

2. Integration Tests
The Rock.Tests.Integration project holds tests that verify the processes and transactions that constitute the business logic of the Rock application.
Tests in this project are categorized into modules that represent the major areas of Rock functionality - for example, Core, CRM, Groups, Security, Events, etc.
These tests often require access to an initialized database containing the standard Rock sample data set, and may also interact with external applications and services.

3. Performance Tests
The Rock.Tests.Performance project stores tests that are intended to measure the performance of some critical components of the Rock application.
These tests are specifically used for benchmarking changes to parts of the codebase where speed and efficiency are important.

## Integration Test or Unit Test?

Determining the appropriate test type for the circumstances is not always easy, but here are some guidelines to keep in mind:
1. Always prefer unit tests.
Unit tests are faster to execute, and require little or no configuration so they can be executed more often. Wherever possible, code components should be designed in a way that allows them to be unit tested. If the code has external dependencies, try to design the component so that the dependencies can be replaced with a mock for testing purposes.
2. If your tests require a database, a RockContext, or access to the SqlServerTypes library, the test belongs in the `Rock.Tests.Integration` project.

## MS Test

This project uses the [Microsoft unit test framework (aka MS Test)](https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code).  You can read more about it in their [Walkthrough](https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code) but it's pretty simple.  You create test classes decorated with `[TestClass]` and individual unit test methods decorated with `[TestMethod]`.

Example:
```csharp
namespace Rock.Tests.Utility.ExtensionMethods
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void AsDouble_ValidInteger()
        {
            var output = @"3".AsDoubleOrNull();
            Assert.That.AreEqual( 3.0d, output );
        }
    }
}
```

## Setup / Test Explorer

If you don't see a Test Explorer tab next to your Solution Explorer, select the "Test" option
      from the main VS menu. Then select Windows > Test Explorer. You should then see the tab. Once
      you build the test project, each test method should appear in the
      explorer. Test methods must be annotated with the [TestMethod] Attribute, and must exist in a class with a [TestClass] Attribute.

## MS Test

### Test Methods

Tests in this project use the "Assert.That.[Assertion]" pattern in preference to the standard "Assert.[Assertion]" pattern.
eg. "Assert.That.AreEqual(a, b);" is preferred to "Assert.AreEqual(a, b);

This is because "Assert.That" allows a consistent syntax for accessing both the standard MSBuild Assert methods and any custom extension methods we have added to extend the Assert functionality as needed.

### FYI: MSTest LifeCycle

The following decorators can give you more control over setup and cleanup for your test suite:

* [AssemblyInitialize] - called once before running the tests of the assembly. 
* [AssemblyCleanup] - called after all tests of the assembly are executed.
* [ClassInitialize] - called once before running the tests of the class.
* [ClassCleanup] - called after all tests from all classes finish.
* [TestInitialize] - called before running each test of the class. 
* [TestCleanup] - called after running each test of the class.
 

 # Test Rules

Tests...

1. should have method names that say what the test is testing .(ex: NumericCodesShouldNotContain911And666). If it fails, you should immediately know what is not working.
2. must have at least one Assert.  ("No Assert, then it's not a test.")
3. must test only one thing. However, you can Assert multiple things about that test to proof it's true.
4. must not depend on the order that tests are run.
5. must not depend on data that may have been destroyed by another test.
6. must not destroy data that other tests are expecting.
7. should not be overly complex with many layers. (KISS principle)
8. shall not write to hard-coded folders. (C://foo/...)
9. should always be able to run in a CI/CD (AppVeyor) environment and without specific/manual setup**.  (Otherwise mark manual tests as [Ignore])

>     **Human only run-able tests (tests that require some specific environment or environment access) should be in a separate test project and class.