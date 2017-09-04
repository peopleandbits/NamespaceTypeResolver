using System;
using System.Text;

namespace NamespaceTypeResolver
{
    public class NSResult
    {
        public NSResult(string title, string[] entries)
        {
            Title = title;
            Entries = entries;
        }

        public string Title { get; private set; }
        public string[] Entries { get; set; }
        public int EntryCount { get { return Entries == null ? 0 : Entries.Length; } }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"## {Title} ##");
            sb.AppendLine(string.Join(Environment.NewLine, Entries));
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
