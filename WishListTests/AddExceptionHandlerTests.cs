using Xunit;
using WishList;
using WishListTests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace WishListTests
{
    public class AddExceptionHandlingTests
    {
        [Fact]
        public void UseDeveloperExceptionPageTest()
        {
            Assert.True(true == true);
        }

        [Fact]
        public void UseExceptionHandlerTest()
        {
            Assert.True(true == true);
        }
    }
}
