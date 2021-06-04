using System.Collections.Generic;

namespace Filter.Filters
{
    public abstract class Filter
    {
        public abstract string FilterName { get; }
        public abstract FilterCriteria Criteria { get; set; }
        public abstract List<string> Words { get; set; }
        public abstract List<string> Apply();
    }
}
