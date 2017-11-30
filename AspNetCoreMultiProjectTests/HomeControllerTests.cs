using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AspNetCoreMultiProjectTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            var home = new AspNetCoreMultiProject.Controllers.HomeController();
            var result = home.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}
