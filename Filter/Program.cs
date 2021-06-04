using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using Filter.Factory;
using FilterEnums = Filter.Enums;
using Filter.Interfaces;

namespace Filter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string Folderpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent).Parent.FullName;
                string path = Path.Combine(Folderpath, "Input.txt");

                var words = ReadInput(path);

                // Filter criteria
                var filterCriteria = new FilterCriteria('t', 3, true);

                //call Apply method for each filter
                foreach (FilterEnums.Filters filter in Enum.GetValues(typeof(FilterEnums.Filters)))
                {
                    var factory = GetFactory(filter, filterCriteria, words); // return the factory object
                    var filterObj = factory.GetFilter(); // return the filter object 
                    words = filterObj.Apply();
                }

                #region reflection
                ////call filters using reflection
                //foreach (FilterEnums.Filters filter in Enum.GetValues(typeof(FilterEnums.Filters)))
                //{
                //    words = CreateFilterAndCallMethod(filter.ToString(), "ExecuteFilter", words, filterCriteria);

                //}
                #endregion

                DisplayResult(words);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static FilterFactory GetFactory(FilterEnums.Filters filter, FilterCriteria fc, List<string> words)
        {
            FilterFactory factory = null;
            switch (filter)
            {
                case FilterEnums.Filters.VowelInMiddle:
                    factory = new FilterVowelInMiddleFactory(fc, words);
                    break;
                case FilterEnums.Filters.Length:
                    factory = new FilterLengthFactory(fc, words);
                    break;
                case FilterEnums.Filters.Letter:
                    factory = new FilterLetterFactory(fc, words);
                    break;
                default:
                    break;

            }

            return factory;
        }
        public static List<string> ReadInput(string path)
        {
            var result = new List<string>();

            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Remove all punctuations and replace with space
                    line = Regex.Replace(line, @"[^\w\d\s]", " ");
                    result.AddRange(line.Split(" "));
                }
            }

            // Remove all empty strings from the list
            result = result.Where(str => !string.IsNullOrEmpty(str)).ToList();
            return result;
        }
        public static void DisplayResult(List<string> words)
        {
            Console.WriteLine(string.Join(" ", words));
            Console.ReadLine();
        }

        /// <summary>
        /// Using reflection to loop through filters
        /// </summary>
        /// <param name="filter">filter type</param>
        /// <param name="methodName">method name to invoke</param>
        /// <param name="words">List of words to filter</param>
        /// <param name="fc">FilterCriteria</param>
        /// <returns></returns>
        private static List<string> CreateFilterAndCallMethod(string filter, string methodName, List<string> words, FilterCriteria fc)
        {
            var result = new List<string>();
            Type type = Type.GetType("Filter.Filters.Filter" + filter);
            object[] parametersArrayConstructor = new object[] { fc, words };
            var filterType = (IFilter)Activator.CreateInstance(type, parametersArrayConstructor);
            var parameterTypes = new Type[] { typeof(List<string>) };
            object[] parametersArray = new object[] {  words };

            var method = type.GetMethod(methodName);
            result = (List<string>) method.Invoke(filterType, parametersArray);
            
            return result;
        }
    }
}
