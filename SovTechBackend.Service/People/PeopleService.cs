
using SovTechBackend.Service.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SovTechBackend.Service.People
{
    public class PeopleService : IPeopleService
    {
        public PeopleService(){}
        public async Task<PeopleDTO> GetAllPeoples()
        {
            string Baseurl = "https://swapi.dev/api/";
            PeopleDTO people = new PeopleDTO();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();                
                //Sending request to find web api REST service resource Category List using HttpClient               
                HttpResponseMessage Res = await client.GetAsync("people");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var responseData = Res.Content.ReadAsStringAsync().Result;
                    people = JsonConvert.DeserializeObject<PeopleDTO>(responseData, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                }
            }
            return people;
        }

        public async Task<PeopleDTO> SearchPeople(string query)
        {
            string Baseurl = "https://swapi.dev/api/";
            PeopleDTO people = new PeopleDTO();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource Category List using HttpClient               
                HttpResponseMessage Res = await client.GetAsync("people/?search=" +query);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var responseData = Res.Content.ReadAsStringAsync().Result;
                    people = JsonConvert.DeserializeObject<PeopleDTO>(responseData, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                }
            }
            return people;
        }
    }
}
