using System;
using System.Linq;
using System.Reflection;

namespace NamespaceTypeResolver
{
    public class NSResolver
    {
        #region Public API
        public NSResult GetTypesInNS(NSInput nsi) => new NSResult(nsi.ToString(), GetFilteredTypeTitles(nsi));

        public static Assembly GetAssemblyByName(string name) => AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(a => a.GetName().Name == name);
        #endregion

        #region Private API
        static string[] GetFilteredTypeTitles(NSInput nsi)
        {
            var all = GetAssemblyByName(nsi.Asm).GetTypes();
            var valid = all.Where(c => IsValidNamespace(c, nsi));
            var filtered = valid.Where(c => nsi.Filter(c));
            var ordered = filtered.OrderBy(c => c.Name);
            var whitelisted = ordered.Where(c => !IsBlacklisted(c, nsi));
            var friendlyNamed = whitelisted.Select(c => new FriendlyNameResolver(c).GetTypeTitle());
            return friendlyNamed.ToArray();
        }

        static bool IsValidNamespace(Type t, NSInput nsi)
        {
            if (string.IsNullOrEmpty(t.Namespace))
                return false;

            return t.Namespace == nsi.NameSpace;
        }

        static bool IsBlacklisted(Type t, NSInput nsi)
        {
            bool startBlacklisted = !string.IsNullOrEmpty(nsi.StartsWithBlacklist) && t.Name.StartsWith(nsi.StartsWithBlacklist);
            bool containsBlacklisted = nsi.ContainsBlacklist != null && nsi.ContainsBlacklist.Any(c => t.Name.Contains(c));
            return startBlacklisted || containsBlacklisted;
        }
        #endregion
    }
}