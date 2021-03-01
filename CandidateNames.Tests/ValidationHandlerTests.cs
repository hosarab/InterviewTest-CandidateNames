using Application.CandidateNames.Validations;
using FluentAssertions;
using Xunit;

namespace CandidateNames.Tests
{
    public class ValidationHandlerTests
    {
        private readonly ValidateProxy _modelUnderTest;
        public ValidationHandlerTests()
        {
            _modelUnderTest = new ValidateProxy();
        }

        [Theory]
        [InlineData("Rebecca")]
        [InlineData("Long ,,Pigford")]
        [InlineData("Marceline ,Polley")]
        [InlineData("Gudrun&nbsp;&nbsp;  ,Caughman")]
        [InlineData("Carrie,  Kirker")]
        [InlineData("carrie, Kirker")]
        public void Should_Be_ReturnFalse_InvalidNames_Test(string arg)
        {
            // Act
            var valid = _modelUnderTest.Validate(arg);
            // Assert
            valid.Should().BeFalse();
        }

        [Theory]
        [InlineData("Carrie, Kirker")]
        public void Should_Be_True_WhenTheValid_GivenName_Test(string arg)
        {
            // Act
            var valid = _modelUnderTest.Validate(arg);
            // Assert
            valid.Should().BeTrue();
        }
    }
}
