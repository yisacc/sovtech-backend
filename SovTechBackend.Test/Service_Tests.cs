using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using SovTechBackend.Service.categories;
using SovTechBackend.Service.DTOs;
using SovTechBackend.Service.Joke;
using SovTechBackend.Service.People;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SovTechBackend.Test
{
    public class Service_Tests
    {
        HttpClientHandler _httpClientHandler=new HttpClientHandler();
        CategoryService categoryService = new CategoryService();
        JokeService jokeService = new JokeService();
        PeopleService peopleService = new PeopleService();
        string CategoriesBaseurl = "https://api.chucknorris.io/jokes/";
        string JokesBaseurl = "https://api.chucknorris.io/";
        string PeopleBaseurl = "https://swapi.dev/api/";




        [Fact]
        public void GetCategories_ReturnsCategoriesList()
        {
            List<string> categories = new List<string>();
            var categoriesList = categoryService.GetCategories().Result;

            var result = _httpClientHandler.Get($"{CategoriesBaseurl}categories");
            categories = JsonConvert.DeserializeObject<List<string>>(result.Content.ReadAsStringAsync().Result);

            Assert.Equal(categoriesList[0], categories[0]);
            Assert.Equal(categoriesList[1], categories[1]);
            Assert.Equal(categoriesList[2], categories[2]);
        }

        [Fact]
        public void SearchCategory_ReturnsCategoriesList()
        {
            var query = "test";
            List<string> categories = new List<string>();
            var categoriesList = categoryService.SearchCategory(query).Result;

            var result = _httpClientHandler.Get($"{CategoriesBaseurl}categories/?search={query}");

            categories = JsonConvert.DeserializeObject<List<string>>(result.Content.ReadAsStringAsync().Result);


            Assert.Equal(categoriesList[0], categories[0]);
            Assert.Equal(categoriesList[1], categories[1]);
            Assert.Equal(categoriesList[2], categories[2]);
        }

        [Fact]
        public void SearchJokes_ReturnsJokesList()
        {
            JokeDTO jokes = new JokeDTO();
            var categoriesList = categoryService.GetCategories().Result;
            var jokesList = jokeService.SearchJokes(categoriesList[0]).Result;
            var result = _httpClientHandler.Get($"{JokesBaseurl}jokes/search?query={categoriesList[0]}");


            jokes = JsonConvert.DeserializeObject<JokeDTO>(result.Content.ReadAsStringAsync().Result);

            Assert.Equal(jokesList.Total, jokes.Total);
            Assert.Equal(jokesList.Result[0].Value, jokes.Result[0].Value);
            Assert.Equal(jokesList.Result[0].Id, jokes.Result[0].Id);
            Assert.Equal(jokesList.Result[0].Url, jokes.Result[0].Url);
        }

        [Fact]
        public void GetRandomJoke_ReturnsJoke()
        {
            JokeModel jokes = new JokeModel();
            var categoriesList = categoryService.GetCategories().Result;
            var jokesList = jokeService.GetRandomJoke(categoriesList[0]).Result;
            var result = _httpClientHandler.Get($"{JokesBaseurl}jokes/random?category={categoriesList[0]}");

            jokes = JsonConvert.DeserializeObject<JokeModel>(result.Content.ReadAsStringAsync().Result);

            Assert.NotNull(jokesList.Value);
            Assert.NotNull(jokesList.Id);
            Assert.NotNull(jokes.Value);
            Assert.NotNull(jokes.Id);
        }

        [Fact]
        public void GetAllPeoples_ReturnsPeopleList()
        {
            PeopleDTO people = new PeopleDTO();
            var peopleList = peopleService.GetAllPeoples().Result;
            var result = _httpClientHandler.Get($"{PeopleBaseurl}people");

            people = JsonConvert.DeserializeObject<PeopleDTO>(result.Content.ReadAsStringAsync().Result);

            Assert.Equal(peopleList.Results.Count,people.Results.Count);
            Assert.Equal(peopleList.Results[0].Name, people.Results[0].Name);
            Assert.Equal(peopleList.Results[0].Height, people.Results[0].Height);
            Assert.Equal(peopleList.Results[0].Mass, people.Results[0].Mass);
        }

        [Fact]
        public void SearchPeople_ReturnsPeopleList()
        {
            var query = "fghh";
            PeopleDTO people = new PeopleDTO();
            var peopleList = peopleService.SearchPeople(query).Result;
            var result = _httpClientHandler.Get($"{PeopleBaseurl}people/?search={query}");

            people = JsonConvert.DeserializeObject<PeopleDTO>(result.Content.ReadAsStringAsync().Result);

            Assert.Equal(peopleList.Results.Count, people.Results.Count);
        }
    }
}
