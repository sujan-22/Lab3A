using DocumentFormat.OpenXml.Bibliography;
using Prometheus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Book : Media, IEncryptable, ISearchable
    {
        public string Author { get; protected set; }
        public string Summary { get; protected set; }

        public Book(string title, int year, string author, string summary)
            : base(title, year)
        {
            Author = author;
            Summary = summary;
        }

        public string Encrypt()
        {
            // Implement encryption logic (e.g., ROT13) for the Summary
            // Return the encrypted Summary
            // You can implement ROT13 or any other encryption method here
            return "EncryptedSummary";
        }

        public string Decrypt()
        {
            char[] summaryChars = Summary.ToCharArray();

            for (int i = 0; i < summaryChars.Length; i++)
            {
                char c = summaryChars[i];
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    summaryChars[i] = (char)((c - baseChar + 13) % 26 + baseChar);
                }
            }

            return new string(summaryChars);
        }

        public new bool Search(string key)
        {
            return Title.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0;
        }


        public override string ToString()
        {
            return ($"Book Title: {Title} ({Year}) \nAuthor: {Author}");
        }
    }

}
