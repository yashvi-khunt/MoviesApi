﻿using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Title { get; set; }
        public string? Summary {  get; set; }
        public bool InTheaters {  get; set; }
        public DateTime ReleaseDate {  get; set; }
        public string? Poster {  get; set; }

        public List<MoviesActors> MoviesActors { get; set; }
        public List<MoviesGenres> MoviesGenres { get; set;}
    }
}
