
using SovTechBackend.Service.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SovTechBackend.Service.People
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
    }
}
