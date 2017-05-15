using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DeveloperBlogTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            var home = new DeveloperBlog.Controllers.HomeController();
            var result = home.Index();
            Assert.IsType(typeof(ViewResult), result);
        }
    }
}
