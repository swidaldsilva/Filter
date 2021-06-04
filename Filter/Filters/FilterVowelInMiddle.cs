using Filter.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FilterEnums = Filter.Enums;

namespace Filter.Filters
{
    public class FilterVowelInMiddle : Filter, IFilter
    {
        private readonly string _filterName;
        private FilterCriteria _filterCriteria;
        private List<string> _words;

        public override string FilterName
        {
            get { return _filterName; }
        }

        public override FilterCriteria Criteria
        {
            get { return _filterCriteria; }
            set { _filterCriteria = value; }
        }

        public override List<string> Words
        {
            get { return _words; }
            set { _words = value; }
        }

        public FilterVowelInMiddle(FilterCriteria filterCriteria, List<string> words)
        {
            _filterCriteria = filterCriteria;
            _filterName = FilterEnums.Filters.VowelInMiddle.ToString();
            _words = words;
        }

        public override List<string> Apply()
        {
            return ExecuteFilter(_words);
        }

        public List<string> ExecuteFilter(List<string> words)
        {
            List<string> result = words;
            if (_filterCriteria.FilterVowelInMiddle.HasValue && _filterCriteria.FilterVowelInMiddle.Value == true)
            {
                var evenLetterWords = words.Where(str => str.Length % 2 == 0 && Regex.IsMatch(str.Substring((str.Length / 2) - 1, 2), "[AEIOUaeiou]")).ToList();
                var oddLetterWords = words.Where(str => str.Length % 2 != 0 && Regex.IsMatch(str.Substring((str.Length / 2) , 1), "[AEIOUaeiou]")).ToList();

                words = words.Except(evenLetterWords).ToList();
                result = words.Except(oddLetterWords).ToList();
            }

            return result;
        }
    }
}
