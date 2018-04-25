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
                             where type.FullName == "WishList.Models.Item"
                             select type).FirstOrDefault();

            Assert.True(itemModel != null, "`Item` class was not found, ensure `Item.cs` contains a `public` class `Item`.");
            var idProperty = itemModel.GetProperty("Id");
            Assert.True(idProperty != null && idProperty.PropertyType == typeof(int), "`Item` class did not contain a `public` `int` property `Id`.");
            var descriptionProperty = itemModel.GetProperty("Description");
            Assert.True(descriptionProperty != null && descriptionProperty.PropertyType == typeof(string), "`Item` class did not contain a `public` `string` property `Description`.");
            Assert.True(descriptionProperty.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault() != null, "`Item` class's `Description` property didn't have a `Required` attribute. (the `RequiredAttribute` can be found in the `System.ComponentModel.DataAnnotations` namespace)");
            Assert.True(((MaxLengthAttribute)descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)?.FirstOrDefault())?.Length == 50, "`Item` class's `Description` property didn`t have a `MaxLength` attribute of `50`.");
        }

        [Fact(DisplayName = "Create Class ApplicationDbContext @create-class-applicationdbcontext")]
        public void CreateApplicationDbContextTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "ApplicationDbContext.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`ApplicationDbContext.cs` was not found in the `Data` folder.");

            var applicationDbContext = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                        from type in assembly.GetTypes()
                                        where type.FullName == "WishList.Data.ApplicationDbContext"
                                        select type).FirstOrDefault();

            Assert.True(applicationDbContext != null, "`ApplicationDbContext` class was not found, ensure `ApplicationDbContext.cs` contains a `public` class `AplicationDbContext`.");
            Assert.True(applicationDbContext.BaseType == typeof(DbContext), "`ApplicationDbContext` was found, but did not inherrit the `DbContext` class. (this will require a using directive for the `Microsoft.EntityFrameWorkCore` namespace)");

            //var constructor = applicationDbContext.GetConstructor(new Type[] { typeof(DbContextOptions) });
            //Assert.True(constructor != null, "`ApplicationDbContext` does not appear to contain a constructor accepting a parameter of type `DbContextOptions<ApplicationDbContext>`");
        }

        [Fact(DisplayName = "Add Constructor to ApplictionDbContext @add-constructor-to-applicationdbcontext")]
        public void AddConstructorToApplicationDbContextTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "ApplicationDbContext.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`ApplicationDbContext.cs` was not found in the `Data` folder.");

            var applicationDbContext = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                        from type in assembly.GetTypes()
                                        where type.FullName == "WishList.Data.ApplicationDbContext"
                                        select type).FirstOrDefault();

            Assert.True(applicationDbContext != null, "`ApplicationDbContext` class was not found, ensure `ApplicationDbContext.cs` contains a `public` class `AplicationDbContext`.");
            Assert.True(applicationDbContext.BaseType == typeof(DbContext), "`ApplicationDbContext` was found, but did not inherrit the `DbContext` class. (this will require a using directive for the `Microsoft.EntityFrameWorkCore` namespace)");

            var constructor = applicationDbContext.GetConstructor(new Type[] { typeof(DbContextOptions) });
            Assert.True(constructor != null, "`ApplicationDbContext` does not appear to contain a constructor accepting a parameter of type `DbContextOptions<ApplicationDbContext>`");

            // Verify Base Constructor is Invoked
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
            Assert.True(file.Contains(@"options => options.UseInMemoryDatabase"), @"`Startup.cs`'s `Configure` called `AddDbContext` but did not provide it the arguement `options => options.UseInMemoryDatabase(""WishList"")`.");
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
                                        where type.FullName == "WishList.Data.ApplicationDbContext"
                                        select type).FirstOrDefault();

            Assert.True(applicationDbContext != null, "`ApplicationDbContext` class was not found, ensure `ApplicationDbContext.cs` contains a `public` class `AplicationDbContext`.");
            
            var itemsProperty = applicationDbContext.GetProperty("Items");
            Assert.True(itemsProperty != null, "`ApplicationDbContext` class did not contain a `public` `Items` property.");
            Assert.True(itemsProperty.PropertyType.GenericTypeArguments[0].ToString() == "WishList.Models.Item", "`ApplicationDbContext` class's `Items` property was not of type `DbSet<Item>`.");
        }
    }
}
