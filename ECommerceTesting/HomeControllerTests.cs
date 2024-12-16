using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Controllers;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

using Xunit;

namespace ECommerceTesting
{
    public class HomeControllerTests
    {
        [Fact]
        public void Repo_check()
        {
            //Arrange
            Mock<IStoreRepository> mock=new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] { new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 1, Name = "P2" } }).AsQueryable<Product>);
            HomeController controller=new HomeController(mock.Object);
            //Act
            IEnumerable<Product?>result=(controller.Index()as ViewResult)?.ViewData.Model as IEnumerable<Product?>; //Getting data from action method as a ViewResult object and casting it to veiwdata.model
            //Assert
            Product[] prodArray=result?.ToArray()?? Array.Empty<Product>();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);

        }
    }
}
