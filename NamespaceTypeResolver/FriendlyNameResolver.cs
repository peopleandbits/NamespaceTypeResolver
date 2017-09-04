using System;
using System.Linq;

namespace NamespaceTypeResolver
{
    public class FriendlyNameResolver
    {
        public FriendlyNameResolver(Type t)
        {
            _T = t;
        }

        Type _T;

        public string GetTypeTitle() => $"{GetFriendlyName()}";

        public string GetFriendlyName()
        {
            if (!_T.IsGenericType)
                return _T.Name;

            string temp = GetGenericNameWithoutMark();
            var parameters = _T.GetGenericArguments().Select(x => new FriendlyNameResolver(x).GetFriendlyName());

            return $"{temp}<{string.Join(", ", parameters)}>";
        }

        public string GetGenericNameWithoutMark()
        {
            var markIndex = _T.Name.IndexOf('`');
            return markIndex != 0 ? _T.Name.Substring(0, markIndex) : _T.Name;
        }
    }
}
