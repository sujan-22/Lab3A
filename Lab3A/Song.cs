/*
  Class:           Song.cs
  Author:          Sujan Rokad
  Student number:  000882948
  Date:            October 30, 2023

  Purpose:         This interface has one method that classes making use of must
                   implement. 

*/

/// <summary>
/// The class implementing the Search() method will be assumed to
/// use a string search key as a parameter and return a boolean
/// value to indicate if that key was successfully found.
/// </summary>
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Song : Media, IEncryptable, ISearchable
    {
        public string Album { get; protected set; }
        public string Artist { get; protected set; }

        public Song(string title, int year, string album, string artist)
            : base(title, year)
        {
            Album = album;
            Artist = artist;
        }

        public string Encrypt()
        {
            throw new NotImplementedException();
        }

        public string Decrypt()
        {
            throw new NotImplementedException();
        }

        public new bool Search(string key)
        {
            return Title.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public override string ToString()
        {
            return ($"Song Title: {Title} ({Year}) \nAlbum: {Album}, Artist: {Artist}");
        }
    }
}
