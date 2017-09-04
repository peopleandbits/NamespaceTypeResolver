using System;

namespace NamespaceTypeResolver
{
    public class NSInput
    {
        /// <summary>
        /// Contructor for NSInput.
        /// </summary>
        /// <param name="asm">An assembly.</param>
        /// <param name="ns">A namespace.</param>
        /// <param name="filter">Default filter (when null) looks for public classes and interfaces.</param>
        public NSInput(string asm, string ns, Predicate<Type> filter = null)
        {
            Asm = asm;
            NameSpace = ns;

            if (filter == null)
                Filter = p => (p.IsClass || p.IsInterface) && p.IsPublic;
            else
                Filter = filter;
        }

        public string Asm { get; set; }
        public string NameSpace { get; set; }
        public Predicate<Type> Filter { get; set; }
        public string StartsWithBlacklist { get; set; } = "<";
        public string[] ContainsBlacklist { get; set; } = new[] { "_", "Comparer", "Exception", "Base" };
        public static string Title { get; set; } = "Types";

        public override string ToString() => GetHeader(Title);

        string GetHeader(string titleType)
        {
            return $"{titleType} in {NameSpace} ({Asm})";
        }
    }

}
