namespace AspNetCoreApp.Tests.TagHelpers
{
    using AspNetCoreApp.Data;
    using AspNetCoreApp.DomainObjects;
    using AspNetCoreApp.Models;
    using Moq;
    using System.Linq;
    using System.Collections.Generic;
    using Xunit;
    using AspNetCoreApp.Controllers;

    public class PageLinkTagHelperTests
    {
        [Theory]
        [InlineData(1, 2)]
        public void CanPaginate(int firstPage, int secondPage)
        {
            // Arrange
            Mock<IRepository<Cat>> mock = new Mock<IRepository<Cat>>();
            mock.Setup(m => m.All()).Returns(new List<Cat> {
                new Cat {Id = 1, Name = "C1"},
                new Cat {Id = 2, Name = "C2"},
                new Cat {Id = 3, Name = "C3"},
                new Cat {Id = 4, Name = "C4"},
                new Cat {Id = 5, Name = "C5"}
            }.AsQueryable());

            HomeController controller = new HomeController(mock.Object);

            // Act
            CatListViewModel firstPageResult = (CatListViewModel)controller.Index(firstPage).ViewData.Model;
            CatListViewModel secondPageResult = (CatListViewModel)controller.Index(secondPage).ViewData.Model;

            // Assert
            CatModel[] firstPageCats = firstPageResult.Cats.ToArray();
            Assert.True(firstPageCats.Length == 3);
            Assert.Equal("C1", firstPageCats[0].Name);
            Assert.Equal("C2", firstPageCats[1].Name);
            Assert.Equal("C3", firstPageCats[2].Name);
            CatModel[] secondPageCats = secondPageResult.Cats.ToArray();
            Assert.True(secondPageCats.Length == 2);
            Assert.Equal("C4", secondPageCats[0].Name);
            Assert.Equal("C5", secondPageCats[1].Name);
        }
    }
}
