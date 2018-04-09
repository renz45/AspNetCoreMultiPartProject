using System;
using System.Linq;
using System.IO;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

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

            // Verify ItemController contains a private property _context of type ApplicationDbContext
            var contextField = controllerType.GetField("_context",BindingFlags.Instance|BindingFlags.NonPublic);
            Assert.True(contextField != null, "`ItemController` was found, but does not appear to contain a `private` `readonly` field `_context` of type `ApplicationDbConetext`.");

            // Verify ItemController contains a constructor has a parameter of type ApplicationDbContext
            var constructor = controllerType.GetConstructor(new Type[] { applicationDbContextType });
            Assert.True(constructor != null, "`ItemController` was found, but did not contain a constructor accepting a parameter of type `ApplicationDbContext`.");

            // Verify _context is set by the constructor's parameter

            //var efServiceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            //var services = new ServiceCollection();
            //services.AddDbContext<ApplicationDbContext>(e => e.UseInMemoryDatabase("Test").UseInternalServiceProvider(efServiceProvider));
            //var serviceProvider = services.BuildServiceProvider();
            
            //var dbContext = serviceProvider.GetRequiredService(applicationDbContextType);
            //var controller = Activator.CreateInstance(controllerType, dbContext);
            
            //var actual = contextProperty.GetValue(controller);
            //Assert.True(actual != null, "`ItemController` was found, but didn't set a `private` property `_context` of type `ApplicationDbContext` to the `ApplicationDbContext` provided to it`s constructor.");
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

            // Verify Index Action Exists
            var method = controllerType.GetMethod("Index");
            Assert.True(method != null, "`ItemController` was found, but does not appear to contain an action `Index` with a return type of `IActionResult`.");

            // Verify Index has the correct return type
            Assert.True(method.ReturnType == typeof(IActionResult),"`ItemController`'s `Index` action was found, but didn't have a return type of `IActionResult`.");

            // Verify Index returns the "Index" view

            // Verify Index returns a model of type List<Item>

            // Verify Index returns all Items contained in contextDb.Items
        }

        [Fact(DisplayName = "Create Item Create HttpGet Action @create-item-create-httpget-action")]
        public void CreateItemCreateHttpGetActionTest()
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

            // Verify Create Action Exists
            var method = controllerType.GetMethod("Create", new Type[] { });
            Assert.True(method != null, "`ItemController` was found, but does not appear to contain an action `Create` with a return type of `IActionResult`.");

            // Verify Create has the correct return type
            Assert.True(method.ReturnType == typeof(IActionResult), "`ItemController`'s `Create` action was found, but didn't have a return type of `IActionResult`.");

            // Verify Create returns the "Create" view
        }

        [Fact(DisplayName = "Create Item Create HttpPost Action @create-item-create-httppost-action")]
        public void CreateItemCreateHttpPostActionTest()
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

            var itemType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  from type in assembly.GetTypes()
                                  where type.FullName == "WishList.Models.Item"
                                  select type).FirstOrDefault();

            Assert.True(itemType != null, "`item` was not found, `Item` should have been created in a previous step, have you accidently deleted or renamed it?");

            // Verify Create Action Exists
            var method = controllerType.GetMethod("Create", new Type[] { itemType });
            Assert.True(method != null, "`ItemController` was found, but does not appear to contain an action `Create` that accepts a parameter of type `Item` with a return type of `IActionResult`.");

            // Verify Create has the correct return type
            Assert.True(method.ReturnType == typeof(IActionResult), "`ItemController`'s `Create` action was found, but didn't have a return type of `IActionResult`.");

            // Verify Create adds the provided Item to dbContext.Items

            // Verify Create redirects to action to the Index action
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

            // Verify Delete Action Exists
            var method = controllerType.GetMethod("Delete");
            Assert.True(method != null, "`ItemController` was found, but does not appear to contain an action `Delete` that accepts a parameter of type `int` with a return type of `IActionResult`.");

            // Verify Create has the correct return type
            Assert.True(method.ReturnType == typeof(IActionResult), "`ItemController`'s `Delete` action was found, but didn't have a return type of `IActionResult`.");

            // Verify Delete removes the matching item from dbContext.Items

            // Verify Delete redirects to action to the Index action
        }
    }
}
