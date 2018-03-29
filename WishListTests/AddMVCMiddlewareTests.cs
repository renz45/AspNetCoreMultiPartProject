using System;
using System.IO;
using Xunit;

namespace WishListTests
{
    public class AddMVCMiddlewareTests
    {
        [Fact]
        public void AddMVCCallAdded()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("app.AddMvc();"), "`Startup.cs`'s `ConfigureServices` did not contain a call to `AddMvc`.");
        }

        [Fact]
        public void UseMVCAdded()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("app.UseMvcWithDefaultRoute();"), "`Startup.cs`'s `ConfigureServices` did not contain a call to `AddMvc`.");
        }
    }
}
