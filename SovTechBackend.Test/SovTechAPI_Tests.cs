using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SovTechBackend.API.Controllers;
using SovTechBackend.Service.categories;
using SovTechBackend.Service.DTOs;
using SovTechBackend.Service.Joke;
using SovTechBackend.Service.People;
using Xunit;

namespace SovTechBackend.Test
{
    public class SovTechAPI_Tests
    {
        Mock<ICategoryService> mockCategoryService = new Mock<ICategoryService>();
        Mock<IJokeService> mockJokeService = new Mock<IJokeService>();
        Mock<IPeopleService> mockPeopleService = new Mock<IPeopleService>();

        #region GetCategoriesTests
        [Fact]
        public void GetCategories_ReturnsSuccess()
        {
            var categories = new ChuckController(mockCategoryService.Object);

            dynamic result = categories.GetCategories();
            Assert.NotNull(result);
        }

        #endregion

        #region GetRandomJoke
        [Fact]
        public void GetRandomJoke_ReturnsSuccess()
        {
            var joke = new JokeController(mockJokeService.Object);
            var category = "animal";
            dynamic result = joke.GetRandomJoke(category);

            Assert.NotNull(result);
        }

        #endregion

        #region GetAllPeople
        [Fact]
        public void GetAllPeople_ReturnsSuccess()
        {
            var joke = new PeopleController(mockPeopleService.Object);
            dynamic result = joke.GetAllPeople();

            Assert.NotNull(result);
        }

        #endregion

        #region Search
        [Fact]
        public void Get_ReturnsSuccess()
        {
            var joke = new SearchController(mockPeopleService.Object,mockJokeService.Object);
            var query = "test";
            dynamic result = joke.Get(query);

            Assert.NotNull(result);
        }

        #endregion
    }
}


