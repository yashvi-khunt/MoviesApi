using MoviesApi.Validations;
using System.ComponentModel.DataAnnotations;
using static MoviesApi.Validations.ContentTypeValidator;

namespace MoviesApi.DTOs
{
    public class MovieCreationDTO : MoviePatchDTO
    {
        [FileSizeValidator(MaxFileSizeInMbs: 4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile? Poster { get; set; }
    }
}
