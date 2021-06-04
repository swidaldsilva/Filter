using Filter.Filters;
using System.Collections.Generic;

namespace Filter.Factory
{
    public class FilterVowelInMiddleFactory : FilterFactory
    {
        private FilterCriteria _filterCriteria;
        private List<string> _words;
        public FilterVowelInMiddleFactory(FilterCriteria fc, List<string> words)
        {
            _filterCriteria = fc;
            _words = words;
        }

        public override Filter.Filters.Filter GetFilter()
        {
            return new FilterVowelInMiddle(_filterCriteria, _words);
        }
    }
}
