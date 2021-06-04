using Filter.Filters;
using System.Collections.Generic;

namespace Filter.Factory
{
    public class FilterLetterFactory : FilterFactory
    {
        private FilterCriteria _filterCriteria;
        private List<string> _words;
        public FilterLetterFactory(FilterCriteria fc, List<string> words)
        {
            _filterCriteria = fc;
            _words = words;
        }

        public override Filter.Filters.Filter GetFilter()
        {
            return new FilterLetter(_filterCriteria, _words);
        }
    }
}
