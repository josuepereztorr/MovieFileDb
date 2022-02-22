using System;
using System.Collections.Generic;

namespace MovieFileDb
{
	public class MovieLibrary
	{
        private List<Movie> library = new List<Movie>();

        public List<Movie> GetLibrary()
        {
            return library;
        }

        public void SetLibrary(List<Movie> library)
        {
            this.library = library;
        }

        public string AddMovie(Movie movie)
        {

            if (!library.Contains(movie))
            {
                library.Add(movie);
                return $"The movie successfully added to our collection";
            }
            else
                return $"The movie already exists in our collection, try another movie";

            
        }

        

    }
}

