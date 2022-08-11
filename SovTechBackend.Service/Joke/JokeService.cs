
using SovTechBackend.Service.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SovTechBackend.Service.Joke
{
    public class JokeService : IJokeService
    {
        private readonly IConfiguration _configuration;
        public JokeService(IConfiguration iconfiguration)
        {
            _configuration = iconfiguration;
        }
     
        public async Task<JokeDTO> SearchJokes(string query)
        {
            string Baseurl = "https://api.chucknorris.io/";
            JokeDTO joke = new JokeDTO();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource Category List using HttpClient               
                HttpResponseMessage Res = await client.GetAsync("jokes/search?query=" + query);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var responseData = Res.Content.ReadAsStringAsync().Result;
                    joke = JsonConvert.DeserializeObject<JokeDTO>(responseData, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                }
            }
            return joke;
        }

        public async Task<JokeModel> GetRandomJoke(string category)
        {
            string Baseurl = "https://api.chucknorris.io/";
            JokeModel joke = new JokeModel();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource Category List using HttpClient               
                HttpResponseMessage Res = await client.GetAsync("jokes/random?category=" + category);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var responseData = Res.Content.ReadAsStringAsync().Result;
                    joke = JsonConvert.DeserializeObject<JokeModel>(responseData, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                }
            }
            return joke;
        }
    }
}
