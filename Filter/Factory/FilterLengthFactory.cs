using Filter.Filters;
using System.Collections.Generic;

namespace Filter.Factory
{
    public class FilterLengthFactory : FilterFactory
    {
        private FilterCriteria _filterCriteria;
        private List<string> _words;
        public FilterLengthFactory(FilterCriteria fc, List<string> words)
        {
            _filterCriteria = fc;
            _words = words;
        }

        public override Filter.Filters.Filter GetFilter()
        {
            return new FilterLength(_filterCriteria, _words);
        }
    }
}
