/*
  Class:           Song.cs
  Author:          Sujan Rokad
  Student number:  000882948
  Date:            October 30, 2023

  Purpose:         This class represents a song as a type of media and implements the IEncryptable and ISearchable interfaces. It provides properties to store information about the song, such as its title, release year, album, and artist. 

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    /// <summary>
    /// Represents a song as a type of media, implementing the IEncryptable and ISearchable interfaces.
    /// </summary>
    public class Song : Media, IEncryptable, ISearchable
    {
        /// <summary>
        /// Gets or sets the album of the song.
        /// </summary>
        public string Album { get; protected set; }

        /// <summary>
        /// Gets or sets the artist of the song.
        /// </summary>
        public string Artist { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the Song class.
        /// </summary>
        /// <param name="title">The title of the song.</param>
        /// <param name="year">The release year of the song.</param>
        /// <param name="album">The album of the song.</param>
        /// <param name="artist">The artist of the song.</param>
        public Song(string title, int year, string album, string artist)
            : base(title, year)
        {
            Album = album;
            Artist = artist;
        }

        /// <summary>
        /// Encrypts the song (Not implemented for this class).
        /// </summary>
        /// <returns>A string representing the encrypted song.</returns>
        public string Encrypt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decrypts the song (Returns a message indicating the summary isn't available).
        /// </summary>
        /// <returns>A string representing the decrypted song summary.</returns>
        public string Decrypt()
        {
            return "Summary isn't available";
        }

        /// <summary>
        /// Searches for the specified key in the song title (case-insensitive).
        /// </summary>
        /// <param name="key">The search key.</param>
        /// <returns>True if the key is found in the title; otherwise, false.</returns>
        public new bool Search(string key)
        {
            return Title.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Overrides the ToString method to provide a formatted string representation of the song.
        /// </summary>
        /// <returns>A formatted string representing the song.</returns>
        public override string ToString()
        {
            return ($"Song Title: {Title} ({Year}) \nAlbum: {Album}, Artist: {Artist}");
        }
    }
}
