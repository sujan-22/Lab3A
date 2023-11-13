/*
  Class:           Movie.cs
  Author:          Sujan Rokad
  Student number:  000882948
  Date:            October 30, 2023
  Authorship:      I, Sujan Rokad, 000882948 certify that this material is my original work.  No other person's work has been used without due acknowledgement.

  Purpose:         This class represents a movie as a type of media and implements the IEncryptable and ISearchable interfaces. It provides properties to store information about the movie, such as its title, release year, director, and summary.

*/

using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    /// <summary>
    /// Represents a movie as a type of media, implementing the IEncryptable and ISearchable interfaces.
    /// </summary>
    public class Movie : Media, IEncryptable, ISearchable
    {
        /// <summary>
        /// Gets or sets the director of the movie.
        /// </summary>
        public string Director { get; protected set; }

        /// <summary>
        /// Gets or sets the summary of the movie.
        /// </summary>
        public string Summary { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the Movie class.
        /// </summary>
        /// <param name="title">The title of the Movie.</param>
        /// <param name="year">The release year of the Movie.</param>
        /// <param name="director">The director of the Movie.</param>
        /// <param name="summary">The summary of the Movie.</param>
        public Movie(string title, int year, string director, string summary)
            : base(title, year)
        {
            Director = director;
            Summary = summary;
        }

        /// <summary>
        /// Encrypts the Movie (Not implemented for this class).
        /// </summary>
        /// <returns>A string representing the encrypted Movie.</returns>
        public string Encrypt()
        {
            return "EncryptedSummary";
        }

        /// <summary>
        /// Decrypts the encrypted summary of the Movie using the ROT13 algorithm.
        /// </summary>
        /// <returns>A string representing the decrypted Movie summary.</returns>
        public string Decrypt()
        {
            // Convert the summary string to a character array for processing
            char[] summaryChars = Summary.ToCharArray();

            // Iterate through each character in the summary
            for (int i = 0; i < summaryChars.Length; i++)
            {
                char c = summaryChars[i];
                int number = (int)c;

                // Check if the character is a letter
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    // Apply ROT13 decryption
                    if (number > 'm' && (c >= 'a' && c <= 'z'))
                    {
                        number -= 13;
                    }
                    else if (number > 'M' && (c >= 'A' && c <= 'Z'))
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                // Update the character in the array with the decrypted value
                summaryChars[i] = (char)number;
            }

            // Return the decrypted summary as a formatted string
            return $"Summary: {new string(summaryChars)}";
        }

        /// <summary>
        /// Searches for the specified key in the Movie title (case-insensitive).
        /// </summary>
        /// <param name="key">The search key.</param>
        /// <returns>True if the key is found in the title; otherwise, false.</returns>
        public new bool Search(string key)
        {
            return Title.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Overrides the ToString method to provide a formatted string representation of the Movie.
        /// </summary>
        /// <returns>A formatted string representing the Movie.</returns>
        public override string ToString()
        {
            return ($"Movie Title: {Title} ({Year}) \nDirector: {Director} ");
        }


    }
}
