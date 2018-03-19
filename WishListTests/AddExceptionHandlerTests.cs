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
            var services = new ServiceCollection();
            var app = new TestApplicationBuilder();
            ((TestServiceProvider)app.ApplicationServices).Populate(services);
            var host = new TestHostingEnvironment() { EnvironmentName = "Development" };
            var startup = new Startup();
            startup.ConfigureServices(((TestServiceProvider)app.ApplicationServices).Services);
            startup.Configure(app, host);

            Assert.True(true == false);
        }

        [Fact]
        public void UseExceptionHandlerTest()
        {
            
        }
    }
}
