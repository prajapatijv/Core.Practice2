using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Practice2.Domain.Models;
using Core.Practice2.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Core.Practice2.Tests
{
    public class AscendingSortServiceTests
    {
        private IFixture fixture;

        public AscendingSortServiceTests()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
        }


        [Fact]
        public async Task Sort_Asc_ShouldSuccess()
        {
            //Arrange
            var products = new List<Product> { { new Product { Name = "A" } }, new Product { Name = "Z" } };
            
            //Act
            var sut = this.fixture.Create<AscendingSortService>();

            var result = await sut.Sort(products);

            Assert.Equal("A", result[0].Name);
            Assert.Equal("Z", result[1].Name);

            //var actual =
            //    Assert.ThrowsAsync<ValidationException>(
            //        async () => await sut.CreateAccount(It.IsAny<int>())).Result;
        }


    }
}
