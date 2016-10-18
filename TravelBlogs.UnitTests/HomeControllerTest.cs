using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.WEB.Controllers;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.BLL.Services;
using TravelBlogs.BLL.DTO;
using Moq;
using System.Web.Mvc;
using TravelBlogs.DAL.Entities;
using AutoMapper;
using System.Linq.Expressions;
using System.Data.Entity;
using EntityFramework.Testing;
using TravelBlogs.BLL.Infrastructure;

namespace TravelBlogs.UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<ITravelBlogsService> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<ITravelBlogsService>();
        }


        [TestMethod]
        public void CanGetCountries()
        {
            // Arrange 
            mock.Setup(m => m.Locations.GetAllCountries()).Returns(new List<CountryDTO>
                {
                    new CountryDTO { Name = "USA", Description = "Films" },
                    new CountryDTO { Name = "Germany", Description = "Beer" },
                    new CountryDTO { Name = "Russia", Description = "Corruption"}
                });

            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.GetCountries() as ViewResult;

            List<CountryDTO> countries = result.Model as List<CountryDTO>;

            // Assert
            Assert.AreEqual(3, countries.Count);
        }

        [TestMethod]
        public void CanFindCountries()
        {
            // Arrange
            List<CountryDTO> countries = new List<CountryDTO> 
            {
                    new CountryDTO { Name = "USA", Description = "Films" },
                    new CountryDTO { Name = "Germany", Description = "Beer" },
                    new CountryDTO { Name = "Russia", Description = "Corruption"}
            };

            mock.Setup(m => m.Locations.Find(It.IsAny<Expression<Func<CountryDTO, Boolean>>>()))
                .Returns<Expression<Func<CountryDTO, Boolean>>>(exp => countries.Where(exp.Compile()).ToList());


            Expression<Func<CountryDTO, bool>> pred = co => co.Name.StartsWith("U");


            // Act
            HomeController controller = new HomeController(mock.Object);
            ViewResult lol = (ViewResult)controller.FindCountries(pred);
            List<CountryDTO> listLol = (List<CountryDTO>)lol.Model;


            // Assert
            Assert.AreEqual("USA", listLol[0].Name);
        }

        [TestMethod]
        public void CanSaveCountry()
        {
            // Arrange
            var mockSet = new Mock<List<CountryDTO>>();
            mock.Setup(c => c.Locations.GetAllCountries()).Returns(mockSet.Object);
            HomeController controller = new HomeController(mock.Object);
            CountryDTO country = new CountryDTO{ Name = "Germany", Description = "Beer" };


            // Act
            ViewResult result = (ViewResult)controller.SaveCountry(country);

            // Assert
            mock.Verify(c => c.Locations.CreateCountry(country), Times.Once());
            mock.Verify(c=>c.SaveChanges(), Times.Once());
        }


        [TestMethod]
        public void Can_Paginate()
        {
            List<PostDTO> posts = new List<PostDTO>
            {
                new PostDTO {Title = "wow", Body = "ajsdhbilaudefliawueh"},
                new PostDTO {Title = "wow", Body = "ajsdhbilaudefliawueh"},
                new PostDTO {Title = "wow", Body = "ajsdhbilaudefliawueh"},
                new PostDTO {Title = "wow", Body = "ajsdhbilaudefliawueh"},
                new PostDTO {Title = "wow", Body = "ajsdhbilaudefliawueh"},
                new PostDTO {Title = "wow", Body = "ajsdhbilaudefliawueh"},
                new PostDTO {Title = "wow", Body = "ajsdhbilaudefliawueh"},
                new PostDTO {Title = "wow", Body = "ajsdhbilaudefliawueh"},
                new PostDTO {Title = "wow", Body = "ajsdhbilaudefliawueh"}
            };

            mock.Setup(m => m.Posts.GetAll(It.IsAny<PagingInfoDTO>()))
                .Returns(posts);

            ITravelBlogsService service = mock.Object;

            PagingInfoDTO paging = new PagingInfoDTO { PageSize = 3, CurrentPage = 200};

            IEnumerable<PostDTO> postDtos = service.Posts.GetAll(paging);
            paging.TotalItems = postDtos.Count();

            Assert.AreEqual(3, paging.CurrentPage);
        }

    }
}

