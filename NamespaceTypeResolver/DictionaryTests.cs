using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace NamespaceTypeResolver
{
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void StringDictionaryTest()
        {
            var sd = new StringDictionary();
            sd.Add("1", "one");
            sd.Add("2", "two");
            sd.Add("3", "three");
            Assert.AreEqual(3, sd.Count);
            Assert.IsTrue(sd["1"] == "one");
        }
        
        [TestMethod]
        public void DictionaryTest()
        {
            var d = new Dictionary<int, string>();
            d.Add(5, "five");
            d.Add(1, "one");
            d.Add(7, "seven");
            d.Add(3, "three");
            Assert.AreEqual(4, d.Count);
            Assert.IsTrue(d.ContainsKey(7));
            Assert.IsTrue(d[7] == "seven");

            string[] arr = d.AsEnumerable().Select(c => $"{c.Key}/{c.Value}").ToArray();
            Assert.IsTrue(Enumerable.SequenceEqual(new[] { "5/five", "1/one", "7/seven", "3/three" }, arr));

            foreach (var item in d)
            {
                Assert.IsNotNull(item.Key);
                Assert.IsNotNull(item.Value);
            }
        }

        [TestMethod]
        public void SortedDictionaryTest()
        {
            var sd = new SortedDictionary<int, string>(TestHelpers.GetTestDict());
            Assert.AreEqual(4, sd.Count);
            Assert.IsTrue(sd.ContainsKey(7));
            Assert.IsTrue(sd[7] == "seven");

            string[] arr = sd.AsEnumerable().Select(c => $"{c.Key}/{c.Value}").ToArray();
            Assert.IsTrue(Enumerable.SequenceEqual(new[] { "1/one", "3/three", "5/five", "7/seven" }, arr));

            foreach (var item in sd)
            {
                Assert.IsNotNull(item.Key);
                Assert.IsNotNull(item.Value);
            }
        }
    }
}