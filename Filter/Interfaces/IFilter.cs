using System.Collections.Generic;

namespace Filter.Interfaces
{
    public interface IFilter
    {
        List<string> ExecuteFilter(List<string> words);
    }
}
