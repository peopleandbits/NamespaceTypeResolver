using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace NamespaceTypeResolver
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void SortedListTest()
        {
            var sl = new SortedList<int, string>(TestHelpers.GetTestDict());

            Assert.AreEqual(4, sl.Count);
            Assert.IsTrue(sl.ContainsKey(7));
            Assert.IsTrue(sl[7] == "seven");

            // indexed access
            Assert.IsTrue(sl.IndexOfValue("one") == 0);
            Assert.IsTrue(sl.IndexOfValue("three") == 1);
            Assert.IsTrue(sl.IndexOfValue("five") == 2);
            Assert.IsTrue(sl.IndexOfValue("seven") == 3);

            string[] arr = sl.AsEnumerable().Select(c => $"{c.Key}/{c.Value}").ToArray();
            Assert.IsTrue(Enumerable.SequenceEqual(new[] { "1/one", "3/three", "5/five", "7/seven" }, arr));

            foreach (var item in sl)
            {
                Assert.IsNotNull(item.Key);
                Assert.IsNotNull(item.Value);
            }
        }

        [TestMethod]
        public void ImmutableListTest()
        {
            var il = ImmutableList.Create(TestHelpers.GetTestList().ToArray());
            var result = il.Add("four"); // let's add one item...

            Assert.IsFalse(il.Contains("four"));
            Assert.AreEqual(3, il.Count);

            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result.Contains("four"));
        }
    }
}