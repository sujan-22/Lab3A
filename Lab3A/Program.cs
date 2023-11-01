/*
  Class:           Program.cs
  Author:          Sujan Rokad
  Student number:  000882948
  Date:            October 30, 2023

  Purpose:         This C# program is designed to manage and interact with a collection of media items, including songs,                  movies, and books. It reads data from a file (Data.txt) and provides users with a menu-driven console                  interface to list, search, and view details of the media items.

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
    public class Program
    {
        private static List<Media> mediaCollection = new List<Media>();

        // Read and store data from Data.txt
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
                            // Split the line into parts
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
                                artist = parts[4].Trim(); // Remove "SONG|" from the beginning

                                Media media = new Song(title, year, album, artist);
                                mediaCollection.Add(media);
                            }
                            else
                            {
                                Console.WriteLine("Invalid data format for SONG: " + line);
                            }

                        } else if (line.StartsWith("MOVIE"))
                        {
                            string[] parts = line.Split('|');
                            string title;
                            int year;
                            string director;

                            if(parts.Length == 4) {
                            
                                title = parts[1].Trim();
                                year = int.Parse(parts[2]);
                                director = parts[3].Trim();

                                string summary = data.ReadLine();
                                Media media = new Movie(title, year, director, summary);
                                mediaCollection.Add(media);
                            
                            } else
                            {
                                Console.WriteLine("Invalid data format for movie: " + line);
                            }
                        } else if (line.StartsWith("BOOK"))
                        {
                            string[] parts = line.Split('|');
                            string title;
                            int year;
                            string author;

                            if (parts.Length == 4)
                            {

                                title = parts[1].Trim();
                                year = int.Parse(parts[2]);
                                author = parts[3].Trim();

                                string summary = data.ReadLine();
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
                        case 1:

                            // List all books
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

                        case 2:

                            // List all movies
                            var movies = mediaCollection.OfType<Movie>();
                            Console.WriteLine(new string('~', 50));
                            Console.WriteLine("List of All Movies:");
                            Console.WriteLine(new string('~', 50));

                            foreach (var movie in movies)
                            {
                                Console.WriteLine(movie.ToString());
                                Console.WriteLine(new string('-', 50));

                                //string decryptedSummary = movie.Decrypt();
                                //Console.WriteLine($"Decrypted Summary: {decryptedSummary}");
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        case 3:

                            // List all songs
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

                        case 4:

                            // List all media
                            foreach (var media in mediaCollection)
                            {
                                Console.WriteLine(media.ToString());
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            break;

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
                                if (media.Search(searchKey))
                                {
                                    Console.WriteLine(media.ToString());
                                    Console.WriteLine();

                                    if (media is Movie movie)
                                    {
                                        foundMatches = true;
                                        Console.WriteLine($"Decrypted Summary: {movie.Decrypt()}");
                                        Console.WriteLine(new string('-', 50));

                                    } else if (media is Book book)
                                    {
                                        foundMatches = true;
                                        Console.WriteLine($"Decrypted Summary: {book.Decrypt()}");
                                        Console.WriteLine(new string('-', 50));
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
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
                
            }
        }
    }
}
