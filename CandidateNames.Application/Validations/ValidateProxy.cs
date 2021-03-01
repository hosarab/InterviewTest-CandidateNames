using Application.CandidateNames.Interfaces;

namespace Application.CandidateNames.Validations
{
    public class ValidateProxy : IValidator
    {
        public bool Validate(string fullname)
        {
            return ValidatorHandler.Validate(fullname);
        }
    }
}
