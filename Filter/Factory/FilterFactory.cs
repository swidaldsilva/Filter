using filter = Filter.Filters;

namespace Filter.Factory
{
    public abstract class FilterFactory
    {
        public abstract filter.Filter GetFilter();
    }
}
