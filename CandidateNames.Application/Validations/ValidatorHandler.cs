using System.Text.RegularExpressions;

namespace Application.CandidateNames.Validations
{
    public class ValidatorHandler
    {
        public static bool Validate(string fullname)
        {
            if (string.IsNullOrEmpty(fullname)) return false;

            var regEx = new Regex("^([A-Z][a-zA-Z]+),\\s([A-Z][a-zA-Z]+)$");
            return regEx.IsMatch(fullname);

        }
    }
}
