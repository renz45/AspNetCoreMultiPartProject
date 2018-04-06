using Xunit;
using System.IO;

namespace WishListTests
{
    public class AddExceptionHandlingTests
    {
        [Fact]
        public void UseDeveloperExceptionPageTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("app.UseDeveloperExceptionPage();"), "`Startup.cs`'s `Configure` did not contain a call to `UseDeveloperExceptionPage`.");
        }

        [Fact]
        public void UseExceptionHandlerTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains(@"app.UseExceptionHandler(""Home/Error"")"), "`Startup.cs`'s `Configure` did not contain a call to `UseExceptionHandler` that redirects to the `Home.Error` action.");
        }
    }
}
