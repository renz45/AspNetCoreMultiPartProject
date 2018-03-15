using System;
using System.IO;
using System.Text.RegularExpressions;
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

            var pattern = @"public void ConfigureServices\s?[(]\s?IServiceCollection services\s?[)]\s*?{\s*?services.AddMvc[(][)];\s*?}";
            var rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            Assert.True(rgx.IsMatch(file), "`Startup.cs`'s `ConfigureServices` did not contain a call to `AddMvc`.");
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

            var pattern = @"public void Configure\s?[(]\s?IApplicationBuilder app\s?,\s?IHostingEnvironment env\s?[)](\s*?.*?)*?app.UseMvcWithDefaultRoute[(][)];\s*?}";
            var rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            Assert.True(rgx.IsMatch(file), "`Startup.cs`'s `ConfigureServices` did not contain a call to `AddMvc`.");
        }
    }
}
