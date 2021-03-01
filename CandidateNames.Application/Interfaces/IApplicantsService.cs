using System.Collections.Generic;

namespace Application.CandidateNames.Interfaces
{
    public interface IApplicantsService
    {
        IEnumerable<string> GetAll();
        IEnumerable<string> GetAllCleaned(IEnumerable<string> applicants);
        string GetInitialsApplicantsNames(string[] applicants);
    }
}