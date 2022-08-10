using SovTechBackend.Service.categories;
using SovTechBackend.Service.Joke;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovTechBackend.API.Controllers
{
    [ApiController]
    [Route("jokes")]
    public class JokeController : ControllerBase
    { 
        private IJokeService _jokeService;
        public JokeController(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        [HttpGet("random")]
        public  async Task<IActionResult> GetRandomJoke(string category)
        {
            var joke = await _jokeService.GetRandomJoke(category);
            if(joke == null)
            {
                return NotFound();
            }
            return Ok(joke);
        }
       
    }
}
