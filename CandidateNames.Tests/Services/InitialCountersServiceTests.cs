using System;
using CandidateNames.Services;
using CandidateNames.Tests.Data;
using Xunit;

namespace CandidateNames.Tests.Services
{
    public class InitialCountersServiceTests
    {
        private readonly InitialCountersService _sut;
        public InitialCountersServiceTests()
        {
            _sut = new InitialCountersService();
        }

        [Fact]
        public void ToString_When_MultipleNames_Then_OutputIsCorrect()
        {
            // Arrange
            const string expectedResult = "A - 1\r\nD - 1\r\nG - 1\r\nR - 1\r\nS - 2\r\n";

            // Act
            foreach (var fullName in ApplicantsSeedData.CleanCandidates)
            {
                _sut.ParserIncrement(fullName);
            }

            var result = _sut.ToString();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ParserIncrement_When_FullNameIsNull_Then_ThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _sut.ParserIncrement(null));
        }

        [Fact]
        public void ParserIncrement_When_FullNameApplied_Then_Incremented()
        {
            // Arrange
            const string expectedResult = "S - 1";

            // Act
            _sut.ParserIncrement("Earlene, Spake");

            var result = _sut.ToString();

            // Assert
            Assert.Contains(expectedResult, result);
        }
    }
}
