using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;

namespace MovieFileDb
{
    class Program
    {

        static void Main(string[] args)
        {

            LibraryService library = new LibraryService();
            HashSet<Movie> movies = library.GetMoviesFromFile();
            int input;

            while (true)
            {
                Console.WriteLine("Movie Library\n-------------");
                Console.WriteLine("1) See Movie Library");
                Console.WriteLine("2) Add Movie");
                Console.WriteLine("3) Exit");
                Console.WriteLine();

                input = Convert.ToInt32(Console.ReadLine());

                if (input == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine();
                    break;
                }

                Console.WriteLine();

                switch (input)
                {
                    case 1:
                        foreach (Movie m in movies)
                        {
                            Console.WriteLine();
                            Console.WriteLine(m.ToString());
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Console.Write("Movie Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Movie Year: ");
                        string year = Console.ReadLine();

                        Console.Write("Movie Genres (seperate with comma and no spaces): ");
                        string genres = Console.ReadLine();

                        library.AddMovie($"{title} ({year})", genres);
                        break;

                }
            }

        }
    }
}

