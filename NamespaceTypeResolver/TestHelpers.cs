using System.Collections.Generic;

namespace NamespaceTypeResolver
{
    public class TestHelpers
    {
        public static IList<string> GetTestList() => new List<string>() { "one", "two", "three" };

        public static  IDictionary<int, string> GetTestDict() => new Dictionary<int, string>() { { 5, "five" }, { 1, "one" }, { 7, "seven" }, { 3, "three" } };
    }
}