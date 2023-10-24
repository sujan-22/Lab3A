using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Program
    {
        private static List<Media> mediaCollection = new List<Media>();
        // Read and store data from Data.txt
        public void Read(string filePath)
        {
            try
            {
                using (StreamReader data = new StreamReader(filePath))
                {
                    string line;
                    while ((line = data.ReadLine()) != null)
                    {
                        // Check if the line starts with "SONG"
                        if (line.StartsWith("SONG"))
                        {
                            // Split the line into parts
                            string[] parts = line.Split('|');

                            if (parts.Length == 4)
                            {
                                string type = parts[0].Trim();
                                string title = parts[1].Trim();
                                int year = int.Parse(parts[2]);
                                string additionalInfo = parts[3].Trim();

                                Media media = null;

                                if (type == "SONG")
                                {
                                    string album = additionalInfo.Split('|')[0].Trim();
                                    string artist = additionalInfo.Split('|')[1].Trim();
                                    media = new Song(title, year, album, artist);
                                }

                                if (media != null)
                                {
                                    mediaCollection.Add(media);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid data format for SONG: " + line);
                            }
                        }
                      
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file:");
                Console.WriteLine(e.Message); // Display the specific error message
            }
        }
        static void Main(string[] args)
        {
            // Create an instance of the Program class
            Program lab = new Program();

            // Read employee data from the CSV file
            lab.Read("Data.txt");

            // Display a menu and implement user interaction
            bool exit = false;
            while (!exit)
            {
                // Define a formatted text menu with options
                string menu =
$@"
------------------------------------------|
                Menu                      |
------------------------------------------|
1) List All Books                         |
2) List All Movies                        |  
3) List All Songs                         |
4) List All Media                         |
5) Search All Media by Title              |
6) Exit                                   |
------------------------------------------|
Enter your choice: ";

                // Display the menu to the user
                Console.Write(menu);

                // variable to store the user's choice
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        // List all books
                        var books = mediaCollection.OfType<Book>();
                        Console.WriteLine("List of All Books:");
                        foreach (var book in books)
                        {
                            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
                        }
                        break;
                    case 2:
                        // List all movies
                        var movies = mediaCollection.OfType<Movie>();
                        Console.WriteLine("List of All Movies:");
                        foreach (var movie in movies)
                        {
                            Console.WriteLine($"Title: {movie.Title}, Director: {movie.Director}");
                        }
                        break;
                    case 3:
                        // List all songs
                        var songs = mediaCollection.OfType<Song>();
                        Console.WriteLine("List of All Songs:");
                        foreach (var song in songs)
                        {
                            Console.WriteLine($"Title: {song.Title}, Album: {song.Album}, Artist: {song.Artist}");
                        }
                        break;
                    case 4:
                        // List all media
                        break;
                    case 5:
                        // Search media by title
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
