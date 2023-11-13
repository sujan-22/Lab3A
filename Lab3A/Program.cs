/*
  Class:           Program.cs
  Author:          Sujan Rokad
  Student number:  000882948
  Date:            October 30, 2023

  Purpose:         This C# program is designed to manage and interact with a collection of media items, including songs, movies, and books. It reads data from a file (Data.txt) and provides users with a menu-driven console interface to list, search, and view details of the media items.

*/

using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2013.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3A
{
    /// <summary>
    /// The main program class for managing and interacting with a collection of media items.
    /// </summary>
    public class Program
    {
        // Collection to store media items
        private static List<Media> mediaCollection = new List<Media>();

        /// <summary>
        /// Reads and stores data from a specified file.
        /// </summary>
        /// <param name="filePath">The path to the file containing media data.</param>
        public static void Read(string filePath)
        {
            try
            {
                using (StreamReader data = new StreamReader(filePath))
                {
                    string line;

                    while ((line = data.ReadLine()) != null)
                    {
                        if (line.StartsWith("SONG"))
                        {
                            // Split the line into parts for song data
                            string[] parts = line.Split('|');
                            string title;
                            int year;
                            string album;
                            string artist;

                            if (parts.Length == 5) // Check that there are 5 parts
                            {
                                title = parts[1].Trim();
                                year = int.Parse(parts[2]);
                                album = parts[3].Trim();
                                artist = parts[4].Trim();

                                // Create and add a new Song object to the collection
                                Media media = new Song(title, year, album, artist);
                                mediaCollection.Add(media);
                            }
                            else
                            {
                                Console.WriteLine("Invalid data format for SONG: " + line);
                            }

                        } 

                        else if (line.StartsWith("MOVIE"))
                        {
                            // Split the line into parts for movie data
                            string[] parts = line.Split('|');
                            string title;
                            int year;
                            string director;

                            if(parts.Length == 4) {
                            
                                title = parts[1].Trim();
                                year = int.Parse(parts[2]);
                                director = parts[3].Trim();

                                // Read the summary
                                string summary = data.ReadLine();

                                // create a new Movie object to add to the collection
                                Media media = new Movie(title, year, director, summary);
                                mediaCollection.Add(media);
                            
                            } 
                            else
                            {
                                Console.WriteLine("Invalid data format for movie: " + line);
                            }
                        } 

                        else if (line.StartsWith("BOOK"))
                        {
                            // Split the line into parts for book data
                            string[] parts = line.Split('|');
                            string title;
                            int year;
                            string author;

                            if (parts.Length == 4)
                            {

                                title = parts[1].Trim();
                                year = int.Parse(parts[2]);
                                author = parts[3].Trim();

                                // Read the summary
                                string summary = data.ReadLine();

                                // create a new Book object to add to the collection
                                Media media = new Book(title, year, author, summary);
                                mediaCollection.Add(media);

                            }
                            else
                            {
                                Console.WriteLine("Invalid data format for book: " + line);
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


        /// <summary>
        /// The main entry point for the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {  
            // Read employee data from the CSV file
            Read("Data.txt");

            // Display a menu and implement user interaction
            bool exit = false;
            while (!exit)
            {
                // Define a formatted text menu with options
                string menu =
$@"
------------------------------------------|
             Media Collection             |
------------------------------------------|
1) List All Books                         |
2) List All Movies                        |  
3) List All Songs                         |
4) List All Media                         |
5) Search All Media by Title              |
                                          |
                                          |
6) Exit                                   |
------------------------------------------|
Enter your choice: ";

                // Display the menu to the user
                Console.Write(menu);

                try
                {
                    // variable to store the user's choice
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        // List all books
                        case 1:

                            var books = mediaCollection.OfType<Book>();
                            Console.WriteLine(new string('~', 50));
                            Console.WriteLine("List of All Books:");
                            Console.WriteLine(new string('~', 50));

                            foreach (var book in books)
                            {
                                Console.WriteLine(book.ToString());
                                Console.WriteLine(new string('-', 50));
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        // List all movies
                        case 2:

                            var movies = mediaCollection.OfType<Movie>();
                            Console.WriteLine(new string('~', 50));
                            Console.WriteLine("List of All Movies:");
                            Console.WriteLine(new string('~', 50));

                            foreach (var movie in movies)
                            {
                                Console.WriteLine(movie.ToString());
                                Console.WriteLine(new string('-', 50));
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        // List all songs
                        case 3:

                            var songs = mediaCollection.OfType<Song>();
                            Console.WriteLine(new string('~', 50));
                            Console.WriteLine("List of All Songs:");
                            Console.WriteLine(new string('~', 50));

                            foreach (var song in songs)
                            {
                                Console.WriteLine(song.ToString());
                                Console.WriteLine(new string('-', 50));
                            }   
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        // List all media
                        case 4:

                            Console.WriteLine(new string('~', 50));
                            Console.WriteLine("List of All Media:");
                            Console.WriteLine(new string('~', 50));
                            foreach (var media in mediaCollection)
                            {
                                Console.WriteLine(media.ToString());
                                Console.WriteLine(new string('-', 50));
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        // Search media by title
                        case 5:
                            Console.Write("Enter the title to search for: ");
                            string searchKey = Console.ReadLine().Trim();
                            Console.WriteLine(new string('~', 50));
                            Console.WriteLine($"Matching media items for '{searchKey}':");
                            Console.WriteLine(new string('~', 50));
                            Thread.Sleep(1000);

                            bool foundMatches = false;

                            foreach (var media in mediaCollection)
                            {
                                if (media is ISearchable searchableMedia)
                                {
                                    if (searchableMedia.Search(searchKey))
                                    {
                                        Console.WriteLine(media.ToString());
                                        Console.WriteLine();

                                        if (media is IEncryptable encryptableMedia)
                                        {
                                            foundMatches = true;
                                            Console.WriteLine(encryptableMedia.Decrypt());
                                            Console.WriteLine(new string('-', 50));
                                        }
                                    }
                                }
                            }

                            if(!foundMatches)
                            {
                                Console.WriteLine("Could not find matching results!");
                            }

                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            break;



                        case 6:

                            Console.WriteLine("Bye!!");
                            exit = true;
                            Thread.Sleep(2000);
                            break;

                        default:

                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                } catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
