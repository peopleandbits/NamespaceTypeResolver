using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace NamespaceTypeResolver
{
    [TestClass]
    public class CollectionsTests
    {
        [TestMethod]
        public void StringCollectionTest()
        {
            var sc = new StringCollection();
            sc.AddRange(new[] { "one", "two", "three" });
            Assert.AreEqual(3, sc.Count);
            Assert.IsTrue(sc.Contains("two"));
        }

        [TestMethod]
        public void ReadOnlyCollectionTest()
        {
            IReadOnlyList<string> rol = new ReadOnlyCollection<string>(TestHelpers.GetTestList());
            Assert.AreEqual(3, rol.Count);
        }
    }
}