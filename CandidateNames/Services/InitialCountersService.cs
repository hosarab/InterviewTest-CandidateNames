using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateNames.Services
{
    public class InitialCountersService
    {
        private readonly SortedList<char, int> _initialsBaseCount;

        public InitialCountersService()
        {
            _initialsBaseCount = new SortedList<char, int>();
        }

        /// <summary>
        /// initiate to count letters for fullname
        /// </summary>
        /// <param name="fullName"></param>
        public void ParserIncrement(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException(nameof(fullName));

            var initChar = fullName
                .ToUpper()
                .Split(',')[1]
                .Trim()
                .ToCharArray()[0];

            IncrementProcess(initChar);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var (key, value) in _initialsBaseCount)
            {
                sb.AppendLine($"{key} - {value}");
            }

            return sb.ToString();
        }
        /// <summary>
        /// Loop through counting for names
        /// </summary>
        /// <param name="applicants"></param>
        /// <returns></returns>
        public string CountOccurInitial(string[] applicants)
        {

            foreach (var fullName in applicants)
            {
                ParserIncrement(fullName);

            }

            return _initialsBaseCount.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private void IncrementProcess(char key)
        {
            if (_initialsBaseCount.TryGetValue(key, out var current))
            {
                _initialsBaseCount.Remove(key);
            }

            var counter = ++current;
            _initialsBaseCount.Add(key, counter);
        }


    }
}