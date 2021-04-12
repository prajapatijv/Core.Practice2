using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Domain.Models;
using Core.Practice2.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Core.Practice2.Tests
{
    public class RecommendedSortServiceTests
    {
        private IFixture fixture;

        public RecommendedSortServiceTests()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
        }


        [Fact]
        public void Sort_Recommended_ShouldThrowException()
        {
            //Arrange
            var sShopperHistoryClientMock = this.fixture.Freeze<Mock<IShopperHistoryClient>>();
            sShopperHistoryClientMock.Setup(m => m.GetShopperHistory()).Throws(new System.Exception("This is test exception"));

            var products = new List<Product> { { new Product { Name = "A", Quantity = 1 } }, new Product { Name = "Z", Quantity = 9 } };

            //Act
            var sut = this.fixture.Create<RecommendedSortService>();
            var actual = Assert.ThrowsAsync<Exception>(async () => await sut.Sort(products)).Result;

            //Assert
            Assert.True(actual.Message == "This is test exception");
            sShopperHistoryClientMock.Verify(v => v.GetShopperHistory(), Times.Once);
        }
    }
}
