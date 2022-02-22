using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;

namespace MovieFileDb
{
	public class LibraryService
	{

        private HashSet<Movie> moviesFromFile = new HashSet<Movie>();

        private List<long> moviesId = new List<long>();

        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		public LibraryService()
        {
            // read the file initially
            ReadMoviesFromFile();

        }

        public HashSet<Movie> GetMoviesFromFile()
        {
            return moviesFromFile;
        }

        public void AddMovie(string title, string genres)
        {
            // create the movie object
            long id = moviesId.Last() + 1;
            Movie movie = new Movie(id, title, genres);
            //string path = Directory.GetCurrentDirectory() + @"/movies.csv";
            string path = @"/Users/josue/Documents/WCTC Courses/NET Databse Programming/week4/MovieFileDb/MovieFileDb/movies.csv";

            // check if the movie already exists in the db, if not add it 
            if (!moviesFromFile.Contains(movie))
            {

                if (File.Exists(path))
                {

                    try
                    {

                        moviesFromFile.Add(movie);
                        moviesId.Add(id);

                        //StreamWriter streamWriter = new StreamWriter(path);
                        //streamWriter.WriteLine(movie.ToDb(), true);
                        //streamWriter.Close();

                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(movie.ToDb());
                        }

                        Console.WriteLine();
                        //ReadMoviesFromFile();

                       
                        Console.WriteLine($"{movie.Title} was successfuly added");

                        Console.WriteLine();

                    }
                    catch (IOException e)
                    {
                        Console.WriteLine();
                        logger.Error(e.Message);
                        
                    }

                }
                else
                {
                    logger.Error("File not found");
                     Console.WriteLine("File not found");
                }

            } else
            {
                 Console.WriteLine($"Good News!\n{movie.Title} is already in our library");
            }


            
        }

        private void ReadMoviesFromFile()
        {
            //string path = Directory.GetCurrentDirectory() + @"/movies.csv";
            string path = @"/Users/josue/Documents/WCTC Courses/NET Databse Programming/week4/MovieFileDb/MovieFileDb/movies.csv";

            if (File.Exists(path))
            {

                try
                {
                    //List<string> list = File.ReadAllLines(path).ToList();

                    StreamReader streamReader = new StreamReader(path);
                    streamReader.ReadLine();

                    while (!streamReader.EndOfStream)
                    {

                        //Movie movie; 
                        string line = streamReader.ReadLine();
                        long movieId = long.Parse(line.Substring(0, line.IndexOf(",")));
                        string title = line.Substring(line.IndexOf(",") + 1, line.LastIndexOf(",") - 7);
                        string genres = line.Substring((line.LastIndexOf(",") + 1), line.Length - (line.LastIndexOf(",") + 1));
                        moviesId.Add(movieId);
                        moviesFromFile.Add(new Movie(movieId, title, genres));

                    }

                    streamReader.Close();

                }
                catch (IOException e)
                {
                    logger.Error(e.Message);
                }

            }
            else
            {
                logger.Error("File not found");
            }
        }

        //public List<long> GetMoviesID()
        //{
        //    return moviesId;
        //}

	}
}

