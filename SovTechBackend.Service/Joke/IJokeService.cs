
using SovTechBackend.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SovTechBackend.Service.Joke
{
    public interface IJokeService
    {       
        Task<JokeDTO> SearchJokes(string query);
        Task<JokeModel> GetRandomJoke(string category);
    }
}
