using SovTechBackend.Service.DTOs;

namespace SovTechBackend.API.Model
{
    public class SearchResultVM
    {
        public PeopleDTO Peoples { get; set; }
        public JokeDTO Jokes { get; set; }
    }
}
