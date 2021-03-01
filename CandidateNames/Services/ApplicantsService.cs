using System.Collections.Generic;
using System.Linq;
using Application.CandidateNames.Interfaces;
using Application.CandidateNames.Validations;

namespace CandidateNames.Services
{
    public class ApplicantsService : IApplicantsService
    {
        private readonly IUserRepository _userRepository;
        private readonly InitialCountersService _initialCounterService;
        public ApplicantsService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _initialCounterService = new InitialCountersService();
        }

        public IEnumerable<string> GetAll()
        {
            var developers = _userRepository.GetDeveloperJobApplicants();
            var tests = _userRepository.GetTesterJobApplicants();

            return developers.Union(tests).Distinct().ToArray();
        }

        public IEnumerable<string> GetAllCleaned(IEnumerable<string> applicants)
        {
            return applicants.ToList().Where(ValidatorHandler.Validate).ToList();
        }

        public string GetInitialsApplicantsNames(string[] applicants)
        {
            return _initialCounterService.CountOccurInitial(applicants);
        }
    }
}
