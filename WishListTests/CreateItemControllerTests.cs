using System;
using System.Linq;
using System.IO;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WishListTests.Helpers;

namespace WishListTests
{
    public class CreateItemControllerTests
    {
        [Fact(DisplayName = "Create ItemController @create-itemcontroller")]
        public void CreateItemControllerTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Controllers" + Path.DirectorySeparatorChar + "ItemController.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`ItemController.cs` was not found in the `Controllers` folder.");

            var controllerType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  from type in assembly.GetTypes()
                                  where type.Name == "ItemController"
                                  select type).FirstOrDefault();

            Assert.True(controllerType != null, "`ItemController.cs` was found, but it appears it does not contain a `public` class `ItemController`.");
            Assert.True(controllerType.BaseType == typeof(Controller), "`ItemController` was found, but does not appear to inherit the `Controller` class from the `Microsoft.AspNetCore.Mvc` namespace.");

            var applicationDbContextType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                            from type in assembly.GetTypes()
                                            where type.Name == "ApplicationDbContext"
                                            select type).FirstOrDefault();

            Assert.True(applicationDbContextType != null, "class `ApplicationDbContext` was not found, this class should already exist in the `Data` folder, if you recieve this you may have accidentally deleted or renamed it.");

            var efServiceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(e => e.UseInMemoryDatabase("Test").UseInternalServiceProvider(efServiceProvider));
            var serviceProvider = services.BuildServiceProvider();

            var itemType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from type in assembly.GetTypes()
                            where type.FullName == "WishList.Models.Item"
                            select type).FirstOrDefault();

            Assert.True(itemType != null, "class `Item` was not found, this class should already exist in the `Models` folder, if you recieve this you may have accidentally deleted or renamed it.");

            var constructor = controllerType.GetConstructor(new Type[] { applicationDbContextType });

            Assert.True(constructor != null, "`ItemController` was found, but did not contain a constructor accepting a parameter of type `ApplicationDbContext`.");

            var dbContext = serviceProvider.GetRequiredService(applicationDbContextType);
            var controller = Activator.CreateInstance(controllerType, dbContext);
            var contextProperty = controllerType.GetProperty("_context",BindingFlags.Instance|BindingFlags.NonPublic);
            Assert.True(contextProperty != null, "`ItemController` was found, but does not appeart to contain a `private` property `_context` of type `ApplicationDbConetext`.");

            var actual = contextProperty.GetValue(controller);
            Assert.True(actual != null, "`ItemController` was found, but didn't set a `private` property `_context` of type `ApplicationDbContext` to the `ApplicationDbContext` provided to it`s constructor.");
        }

        [Fact(DisplayName = "Create Item Index Action @create-item-index-action")]
        public void CreateItemIndexActionTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Controllers" + Path.DirectorySeparatorChar + "ItemController.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`ItemController.cs` was not found in the `Controllers` folder.");

            var controllerType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  from type in assembly.GetTypes()
                                  where type.Name == "ItemController"
                                  select type).FirstOrDefault();

            Assert.True(controllerType != null, "`ItemController.cs` was found, but it appears it does not contain a `public` class `ItemController`.");

            var applicationDbContextType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                            from type in assembly.GetTypes()
                                            where type.Name == "ApplicationDbContext"
                                            select type).FirstOrDefault();

            Assert.True(applicationDbContextType != null, "class `ApplicationDbContext` was not found, this class should already exist in the `Data` folder, if you recieve this you may have accidentally deleted or renamed it.");

            var itemType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from type in assembly.GetTypes()
                            where type.FullName == "WishList.Models.Item"
                            select type).FirstOrDefault();

            Assert.True(itemType != null, "class `Item` was not found, this class should already exist in the `Models` folder, if you recieve this you may have accidentally deleted or renamed it.");

            var constructor = controllerType.GetConstructor(new Type[] { applicationDbContextType });

            Assert.True(constructor != null, "`ItemController` was found, but did not contain a constructor accepting a parameter of type `ApplicationDbContext`.");

            var dbContext = Activator.CreateInstance(applicationDbContextType);
            var controller = Activator.CreateInstance(controllerType, dbContext);
            var method = controllerType.GetMethod("Index");
            Assert.True(method != null, "`ItemController` was found, but does not appear to contain an `Index` action with a return type `IActionResult`.");
            Assert.True(method.ReturnType == typeof(IActionResult), "`ItemController.Index` was found, but did not have a return type of `IActionResult`.");
            var result = (ViewResult)method.Invoke(controller, null);
            Assert.True(result.ViewName == "Index", @"`ItemController.Index` did not return the `Item\Index` view.");
            Assert.True(((List<object>)result.Model)?.Count == 1,"`ItemController` returned the correct view, but the model was not set to a List of all of the items in `_context.Items`.");
        }

        [Fact(DisplayName = "Create Item Create Action @create-item-create-action")]
        public void CreateItemCreateActionTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Controllers" + Path.DirectorySeparatorChar + "ItemController.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`ItemController.cs` was not found in the `Controllers` folder.");

            var controllerType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  from type in assembly.GetTypes()
                                  where type.Name == "ItemController"
                                  select type).FirstOrDefault();

            Assert.True(controllerType != null, "`ItemController.cs` was found, but it appears it does not contain a `public` class `ItemController`.");

            var applicationDbContextType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                            from type in assembly.GetTypes()
                                            where type.Name == "ApplicationDbContext"
                                            select type).FirstOrDefault();

            Assert.True(applicationDbContextType != null, "class `ApplicationDbContext` was not found, this class should already exist in the `Data` folder, if you recieve this you may have accidentally deleted or renamed it.");

            var itemType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from type in assembly.GetTypes()
                            where type.FullName == "WishList.Models.Item"
                            select type).FirstOrDefault();

            Assert.True(itemType != null, "class `Item` was not found, this class should already exist in the `Models` folder, if you recieve this you may have accidentally deleted or renamed it.");
            var item = Activator.CreateInstance(itemType);
            itemType.GetProperty("Description").SetValue(item, "Example Item");

            var constructor = controllerType.GetConstructor(new Type[] { applicationDbContextType });

            Assert.True(constructor != null, "`ItemController` was found, but did not contain a constructor accepting a parameter of type `ApplicationDbContext`.");

            var dbContext = Activator.CreateInstance(applicationDbContextType);
            var controller = Activator.CreateInstance(controllerType, dbContext);
            var method = controllerType.GetMethod("Create");
            Assert.True(method != null, "`ItemController` was found, but did not contain a method `Create`.");
            Assert.True(method.ReturnType == typeof(IActionResult), "`ItemController.Create` was found, but did not have a return type of `IActionResult`.");
            var result = (RedirectToActionResult)method.Invoke(controller, new object[] { item });
            Assert.True(result.ActionName == "Index", @"`ItemController.Create` did not redirect to the `Item\Index` action.");
            Assert.True(((List<object>)applicationDbContextType.GetProperty("items").GetValue(dbContext)).Count == 1, "`ItemController` redirected to the correct action, but didn't add the provided `Item` to `_context.Items` (did you remember to call `SaveChanges`?).");
        }

        [Fact(DisplayName = "Create Item Delete Action @create-item-delete-action")]
        public void CreateItemDeleteActionTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Controllers" + Path.DirectorySeparatorChar + "ItemController.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`ItemController.cs` was not found in the `Controllers` folder.");

            var controllerType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  from type in assembly.GetTypes()
                                  where type.Name == "ItemController"
                                  select type).FirstOrDefault();

            Assert.True(controllerType != null, "`ItemController.cs` was found, but it appears it does not contain a `public` class `ItemController`.");

            var applicationDbContextType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                            from type in assembly.GetTypes()
                                            where type.Name == "ApplicationDbContext"
                                            select type).FirstOrDefault();

            Assert.True(applicationDbContextType != null, "class `ApplicationDbContext` was not found, this class should already exist in the `Data` folder, if you recieve this you may have accidentally deleted or renamed it.");

            var itemType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from type in assembly.GetTypes()
                            where type.FullName == "WishList.Models.Item"
                            select type).FirstOrDefault();

            Assert.True(itemType != null, "class `Item` was not found, this class should already exist in the `Models` folder, if you recieve this you may have accidentally deleted or renamed it.");
            var item = Activator.CreateInstance(itemType);
            itemType.GetProperty("Description").SetValue(item, "Example Item");
            itemType.GetProperty("Id").SetValue(item, 1);

            var constructor = controllerType.GetConstructor(new Type[] { applicationDbContextType });

            Assert.True(constructor != null, "`ItemController` was found, but did not contain a constructor accepting a parameter of type `ApplicationDbContext`.");

            var dbContext = Activator.CreateInstance(applicationDbContextType);
            var list = new List<object>
            {
                item
            };
            applicationDbContextType.GetProperty("Items").SetValue(dbContext, list);

            var controller = Activator.CreateInstance(controllerType, dbContext);
            var method = controllerType.GetMethod("Delete");
            var result = (RedirectToActionResult)method.Invoke(controller, new object[] { 1 });
            Assert.True(result.ActionName == "Index", @"`ItemController.Delete` did not redirect to the `Item\Index` action.");
            Assert.True(((List<object>)applicationDbContextType.GetProperty("items").GetValue(dbContext)).Count == 0, "`ItemController.Delete` redirected to the correct action, but did not remove the matching `Item` from `_context.Items` (did you remember to call `SaveChanges`?).");
        }
    }
}
