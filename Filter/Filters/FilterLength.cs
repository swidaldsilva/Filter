﻿using Filter.Interfaces;
using System.Collections.Generic;
using System.Linq;
using FilterEnums = Filter.Enums;

namespace Filter.Filters
{
    public class FilterLength : Filter, IFilter 
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
        public FilterLength(FilterCriteria filterCriteria, List<string> words)
        {
            _filterCriteria = filterCriteria;
            _filterName = FilterEnums.Filters.Length.ToString();
            _words = words;
        }

        public override List<string> Apply()
        {
            return ExecuteFilter(_words);
        }

        public List<string> ExecuteFilter(List<string> words)
        {
            List<string> result = words;
            if (_filterCriteria.FilterLength.HasValue)
            {
                result = words.Where(str => str.Length >= _filterCriteria.FilterLength.Value).ToList();

            }

            return result;
        }
    }
}
