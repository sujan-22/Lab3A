using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Movie : Media, IEncryptable
    {
        public string Director { get; protected set; }
        public string Summary { get; protected set; }

        public Movie(string title, int year, string director, string summary)
            : base(title, year)
        {
            Director = director;
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
            // Implement decryption logic (e.g., ROT13) for the encrypted Summary
            // Return the decrypted Summary
            // You can implement ROT13 or any other decryption method here
            return "DecryptedSummary";
        }
    }
}
