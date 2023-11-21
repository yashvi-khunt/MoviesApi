using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesApi.Entities;
using MoviesApi.Filters;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;
        public GenresController(IRepository repository,ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }


        [HttpGet]  //api/genres
        [HttpGet("list")]  //api/genres/list
        [HttpGet("/allGenres")]  //allGenres
        //[ResponseCache(Duration = 60)]
        [ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Getting all the genres");
            return await repository.GetAllGenres();
        }

        [HttpGet("{Id:int}" ,Name="getGenre")]
        public ActionResult<Genre> Get(int Id, [BindRequired] string param)
        {
            logger.LogDebug("Get by Id method executing");
            var genre = repository.GetGenreById(Id);

            if (genre == null)
            {
                logger.LogWarning($"Genre with Id {Id} not found");
                return NotFound();
                throw new ApplicationException();
            }
            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            repository.AddGenre(genre);
            return new CreatedAtRouteResult("getGenre", new { Id = genre.Id }, genre);
        }

        [HttpPut]
        public ActionResult Put() 
        {

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete() 
        {
            return NoContent();
        }
    }
}
