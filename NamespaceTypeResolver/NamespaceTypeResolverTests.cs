using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace NamespaceTypeResolver
{
    [TestClass]
    public class NamespaceTypeResolverTests
    {
        [TestMethod]
        public void NSResultTest()
        {
            var all = new List<NSResult>();
            NSInput.Title = "Types and Interfaces";
            var r = new NSResolver();

            all.Add(r.GetTypesInNS(new NSInput("mscorlib", "System.Collections")));
            all.Add(r.GetTypesInNS(new NSInput("mscorlib", "System.Collections.Concurrent")));
            all.Add(r.GetTypesInNS(new NSInput("mscorlib", "System.Collections.Generic")));
            all.Add(r.GetTypesInNS(new NSInput("mscorlib", "System.Collections.ObjectModel")));
            all.Add(r.GetTypesInNS(new NSInput("System",   "System.Collections.Concurrent")));
            all.Add(r.GetTypesInNS(new NSInput("System",   "System.Collections.Generic")));
            all.Add(r.GetTypesInNS(new NSInput("System",   "System.Collections.ObjectModel")));
            all.Add(r.GetTypesInNS(new NSInput("System",   "System.Collections.Specialized")));

            // let's use something from System.Collections.Immutable so it gets loaded.
            var il = ImmutableList.Create("one", "two", "three");

            all.Add(r.GetTypesInNS(new NSInput("System.Collections.Immutable",   "System.Collections.Immutable")));

            //var toBeRemoved = all.Where(c => c.EntryCount == 0);
            //foreach (var item in toBeRemoved.Reverse())
                //all.Remove(item);

            all = all.Where(c => c.EntryCount > 0).ToList(); // remove things you don't need

            Assert.AreEqual(83, all.Sum(c => c.EntryCount));

            var result = string.Join(string.Empty, all).Trim();
            Assert.AreEqual(2348, result.Length);
        }
    }
}