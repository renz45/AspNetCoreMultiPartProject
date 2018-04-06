using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Xunit;

namespace WishListTests
{
    public class CreateItemModelWithEntityFrameworkSupportTests
    {
        [Fact(DisplayName = "Create Item Model @create-item-model")]
        public void CreateItemModelTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Models" + Path.DirectorySeparatorChar + "Item.cs";
            Assert.True(File.Exists(filePath), "`Item.cs` was not found in the `Models` folder.");

            var itemModel = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.Name == "Item"
                             select type).FirstOrDefault();

            Assert.True(itemModel != null, "`Item` class was not found, ensure `Item.cs` contains a `public` class `Item`.");
            var idProperty = itemModel.GetProperty("Id");
            Assert.True(idProperty != null && idProperty.PropertyType == typeof(int), "`Item` class did not contain a `public` `int` property `Id`.");
            var descriptionProperty = itemModel.GetProperty("Description");
            Assert.True(descriptionProperty != null && descriptionProperty.PropertyType == typeof(string), "`Item` class did not contain a `public` `string` property `Description`.");
            Assert.True(descriptionProperty.GetCustomAttributes(typeof(RequiredAttribute), false) != null, "`Item` class's `Description` property didn't have a `Required` attribute.");
            Assert.True(((MaxLengthAttribute)descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)?.FirstOrDefault())?.Length == 50, "`Item` class's `Description` poeprty didn`t have a `MaxLength` attribute of `50`.");
        }

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

            Assert.True(applicationDbContext != null, "`ApplicationDbContext` class was not found, ensure `ApplicationDbContext.cs` contains a `public` class `AplicationDbContext`.");
            Assert.True(applicationDbContext.BaseType == typeof(DbContext));
            // We do not need to test the constructor as the code will not compile until it's resolved
        }

        [Fact(DisplayName = "Configure EntityFramework @configure-entityframework")]
        public void ConfigureEntityFrameworkTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("services.AddDbContext<ApplicationDbContext>"), "`Startup.cs`'s `Configure` did not contain a call to `ApplicationDbContext` with the `ApplicationDbContext` type.");
            Assert.True(file.Contains(".UseInMemoryDatabase"), "`Startup.cs`'s `Configure` did not contain a call to `UseInMemoryDatabase`.");
        }

        [Fact(DisplayName = "Add Item to ApplicationDbContext @add-item-to-applicationdbcontext")]
        public void AddItemToApplicationDbContextTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "ApplicationDbContext.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`ApplicationDbContext.cs` was not found in the `Data` folder.");

            var applicationDbContext = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                        from type in assembly.GetTypes()
                                        where type.Name == "ApplicationDbContext"
                                        select type).FirstOrDefault();

            Assert.True(applicationDbContext != null, "`ApplicationDbContext` class was not found, ensure `ApplicationDbContext.cs` contains a `public` class `AplicationDbContext`.");

            var itemType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from type in assembly.GetTypes()
                            where type.Name == "Item"
                            select type).FirstOrDefault();
            
            var itemsProperty = applicationDbContext.GetProperty("Items");
            Assert.True(itemsProperty != null, "`ApplicationDbContext` class did not contain a `public` `Items` property.");
            Assert.True(itemsProperty.PropertyType == typeof(DbSet<>), "`ApplicationDbContext` class's `Items` property was not of type `DbSet<Item>`.");
        }
    }
}
