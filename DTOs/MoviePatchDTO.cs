using System.ComponentModel.DataAnnotations;

namespace MoviesApi.DTOs
{
    public class MoviePatchDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Title { get; set; }
        public string? Summary { get; set; }
        public bool InTheaters { get; set; }
        public DateTime ReleaseDate { get; set; }
       
    }
}
