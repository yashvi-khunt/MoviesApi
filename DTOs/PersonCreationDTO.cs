using MoviesApi.Validations;
using System.ComponentModel.DataAnnotations;
using static MoviesApi.Validations.ContentTypeValidator;

namespace MoviesApi.DTOs
{
    public class PersonCreationDTO : PersonPatchDTO
    {
        [FileSizeValidator(4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile? Picture { get; set; }
    }
}
