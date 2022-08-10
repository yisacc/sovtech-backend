using SovTechBackend.API.Model;
using SovTechBackend.Service.categories;
using SovTechBackend.Service.People;
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
    [Route("search")]
    public class SearchController : ControllerBase
    {
        private IPeopleService _peopleService;
        private IJokeService _jokService;
        public SearchController(IPeopleService peopleService, IJokeService jokeService)
        {
            _peopleService = peopleService;
            _jokService = jokeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string query)
        {
            SearchResultVM searchResultVM = new SearchResultVM();
            if (query == null)
            {
                return BadRequest();
            }
            else
            {
                var peoples = await _peopleService.SearchPeople(query);
                var jokes = await _jokService.SearchJokes(query);
                searchResultVM.Peoples = peoples;
                searchResultVM.Jokes = jokes;

                if (peoples == null && jokes==null)
                {
                    return NotFound();
                }
                return Ok(searchResultVM);
            }

        }

    }
}
