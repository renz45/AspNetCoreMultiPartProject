using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace WishListTests
{
    public class CreateItemModelWithEntityFrameworkSupport
    {
        [Fact(DisplayName = "Add EntityFramework Support @add-entityframework-support")]
        public void CreateApplicationDbContextTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "ApplicationDbContext.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`ApplicationDbContext.cs` was not found in the `Data` folder.");

            var applicationDbContext = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  from type in assembly.GetTypes()
                                  where type.Name == "ApplicationDbContext"
                                  select type).FirstOrDefault();

            Assert.True(applicationDbContext.BaseType == typeof(DbContext));
            // We do not need to test the constructor as the code will not compile until it's resolved
        }

        [Fact(DisplayName = "Configure EntityFramework @configure-entityframework")]
        public void ConfigureEntityFrameworkTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("services.AddDbContext<ApplicationDbContext>"), "`Startup.cs`'s `Configure` did not contain a call to `ApplicationDbContext` with the `ApplicationDbContext` type.");
            Assert.True(file.Contains(".UseInMemoryDatabase"), "`Startup.cs`'s `Configure` did not contain a call to `UseInMemoryDatabase`.");
        }
    }
}
