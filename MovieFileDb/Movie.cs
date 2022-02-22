using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieFileDb
{
    public class Movie
    {
        public long MovieId { get; set; }
        public string Title { get; set; }
        public List<string> genres = new List<string>();

        public Movie(long movieId, string title, string genres)
        {
            MovieId = movieId;
            Title = title;
            AddGenre(genres);
        }

        public string GetGenres()
        {
            return String.Join("|", genres.ToArray());
        }

        public string GetGenresSimply()
        {
            return String.Join(",", genres);
        }

        private void AddGenre(string genre)
        {

            string[] genreArr = genre.Split(",");

            foreach (string g in genreArr)
            {
                genres.Add(g);
            }
        }

        public override string ToString()
        {
            return $"Id: {MovieId}\nTitle: {Title}\nGenres: {GetGenresSimply()}";
        }

        public string ToDb()
        {
            return $"{MovieId},{Title},{GetGenres()}";
        }
    }
}

