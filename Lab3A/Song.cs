using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Song : Media, IEncryptable
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
            // Encrypt the Album and Artist using LINQ
            string encryptedAlbum = new string(Album.Select(EncryptCharacter).ToArray());
            string encryptedArtist = new string(Artist.Select(EncryptCharacter).ToArray());

            // Return the encrypted Song information
            return $"{Title} ({Year}) - Album: {encryptedAlbum}, Artist: {encryptedArtist}";
        }

        public string Decrypt()
        {
            // Decrypt the Album and Artist using LINQ
            string decryptedAlbum = new string(Album.Select(DecryptCharacter).ToArray());
            string decryptedArtist = new string(Artist.Select(DecryptCharacter).ToArray());

            // Return the decrypted Song information
            return $"{Title} ({Year}) - Album: {decryptedAlbum}, Artist: {decryptedArtist}";
        }

        // Helper method to encrypt a character (you can define your own encryption logic here)
        private char EncryptCharacter(char c)
        {
            // Example: Shift each character by 1
            return (char)(c + 1);
        }

        // Helper method to decrypt a character (you can define your own decryption logic here)
        private char DecryptCharacter(char c)
        {
            // Example: Shift each character back by 1
            return (char)(c - 1);
        }
    }
}
