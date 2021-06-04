namespace Filter
{
    public class FilterCriteria
    {
        public FilterCriteria(char? ch, int? length, bool? filterVowel)
        {
            FilterCharachter = ch;
            FilterLength = length;
            FilterVowelInMiddle = filterVowel;
        }
        public char? FilterCharachter { get; set; }
        public int? FilterLength { get; set; }
        public bool? FilterVowelInMiddle { get; set; }
    }
}
