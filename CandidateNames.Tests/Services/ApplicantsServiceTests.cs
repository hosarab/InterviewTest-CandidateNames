using Application.CandidateNames.Interfaces;
using CandidateNames.Services;
using CandidateNames.Tests.Data;
using Moq;
using Xunit;

namespace CandidateNames.Tests.Services
{
    public class ApplicantsServiceTests
    {
        private readonly ApplicantsService _sut;
        private readonly Mock<IUserRepository> _mockedRepository;
        public ApplicantsServiceTests()
        {
            _mockedRepository = new Mock<IUserRepository>();
            _sut = new ApplicantsService(_mockedRepository.Object);
        }

        [Fact]
        public void CleanList_WhenArrayIsEmpty_ThenReturnsEmpty()
        {
            // Arrange
            var emptyArray = new string[] { };
            // Assert
            Assert.Empty(_sut.GetAllCleaned(emptyArray));
        }


        [Fact]
        public void Given_AllCandidateNames_ReturnCleanNamesList()
        {
            // Arrange
            var result = _sut.GetAllCleaned(ApplicantsSeedData.DirtyTesterCandidates);

            // Assert
            Assert.Collection(result,
                name => Assert.Equal("Jones, David", name),
                name => Assert.Equal("Scarlet, Solis", name));
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsCandidatesNoDuplicates()
        {
            // Arrange
            _mockedRepository.Setup(r => r.GetDeveloperJobApplicants()).Returns(ApplicantsSeedData.DirtyDeveloperCandidates);
            _mockedRepository.Setup(r => r.GetTesterJobApplicants()).Returns(ApplicantsSeedData.DirtyTesterCandidates);

            // Act
            var results = _sut.GetAllCleaned(_sut.GetAll());

            // Assert
            Assert.Equal(ApplicantsSeedData.CleanCandidates, results);
        }

        [Fact]
        public void Expected_Invocation_On_The_Mock_AtLeast_Once()
        {
            // Arrange
            _mockedRepository.Setup(r => r.GetDeveloperJobApplicants()).Returns(ApplicantsSeedData.DirtyDeveloperCandidates);
            _mockedRepository.Setup(r => r.GetTesterJobApplicants()).Returns(ApplicantsSeedData.DirtyTesterCandidates);

            // Act
            _sut.GetAllCleaned(_sut.GetAll());

            // Assert
            _mockedRepository.Verify(mock => mock.GetTesterJobApplicants(), Times.Once());
            _mockedRepository.Verify(mock => mock.GetDeveloperJobApplicants(), Times.Once());
        }
    }

}
