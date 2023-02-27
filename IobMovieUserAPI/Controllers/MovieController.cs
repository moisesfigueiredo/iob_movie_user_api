using IobMovieUserAPI.Business;
using IobMovieUserAPI.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace IobMovieUserAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MovieController : ControllerBase
    {

        private readonly ILogger<MovieController> _logger;

        private IMovieBusiness _MovieBusiness;

        public MovieController(ILogger<MovieController> logger, IMovieBusiness MovieBusiness)
        {
            _logger = logger;
            _MovieBusiness = MovieBusiness;
        }

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(List<MovieVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
    
        public IActionResult Get(
            [FromQuery] string title,
            string sortDirection,
            int pageSize,
            int page)
        {
            var data = _MovieBusiness.FindWithPagedSearch(title, sortDirection, pageSize, page);
            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(MovieVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
    
        public IActionResult Get(long id)
        {
            var Movie = _MovieBusiness.FindByID(id);
            if (Movie == null) return NotFound();
            return Ok(Movie);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(MovieVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
    
        public IActionResult Post([FromBody] MovieVO Movie)
        {
            if (Movie == null) return BadRequest();
            return Ok(_MovieBusiness.Create(Movie));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(MovieVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
    
        public IActionResult Put([FromBody] MovieVO Movie)
        {
            if (Movie == null) return BadRequest();
            return Ok(_MovieBusiness.Update(Movie));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _MovieBusiness.Delete(id);
            return NoContent();
        }
    }
}
