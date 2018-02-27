# ASP.NET Core WishList Application

The ASP.NET Core WishList Application is designed to allow users to create their own wishlists, and other users to mark that they are buying those items in such a way the owner of the wish list isn't able to see, while other users are able to see. This application is designed using the Model View Controller design pattern.

Note: This project is the first in a series of four projects, this project will cover taking an empty ASP.NET Core web application, setting up it's middleware to support MVC and EntityFramework, then creating a simple

# Setup the Application

## If you want to use Visual Studio
If you want to use Visual Studio (highly recommended) follow the following steps:
-   If you already have Visual Studio installed make sure you have .Net Core installed by running the "Visual Studio Installer" and making sure ".NET Core cross-platform development" is checked
-   If you need to install visual studio download it at https://www.microsoft.com/net/download/ (If you'r using Windows you'll want to check "ASP.NET" and ".NET Core cross-platform development" on the workloads screen during installation.)
-   Open the .sln file in visual studio
-   To run the application simply press the Start Debug button (green arrow) or press F5
-   If you're using Visual Studio on Windows, to run tests open the Test menu, click Run, then click on Run all tests (results will show up in the Test Explorer)
-   If you're using Visual Studio on macOS, to run tests, select the GradeBookTests Project, then go to the Run menu, then click on Run Unit Tests (results will show up in the Unit Tests panel)

(Note: All tests should fail at this point, this is by design. As you progress through the projects more and more tests will pass. All tests should pass upon completion of the project.)

## If you don't plan to use Visual studio
If you would rather use something other than Visual Studio
-   Install the .Net Core SDK from https://www.microsoft.com/net/download/core once that installation completes you're ready to roll!
-   To run the application go into the GradeBook project folder and type `dotnet run`
-   To run the tests go into the GradeBookTests project folder and type `dotnet test`

# Features you will impliment

- Setup and configure middleware to support MVC
- Create the ability to view your wishlist
- Create the ability add items to your wish list
- Create the ability to remove items from your wishlist

## Tasks necessary to complete implimentation:

__Note:__ this isn't the only way to accomplish this, however; this is what the project's tests are expecting. Implimenting this in a different way will likely result in being marked as incomplete / incorrect.

- [ ] Creating ASP.NET Core Application from scratch
	- [ ] Add Middleware/Configuration to `Startup.cs`
		- [ ] In the `Startup.cs` file add support for the MVC middleware and configure it to have a default route.
			- In the `ConfigureServices` method add `AddMVC` to add support for MVC middleware.
			- In the `Configure` method add `UseMVC`.
				- Provide `UseMVC` with default Controller/Action/Id Route (defaulting to the "Home" controller and "Index" action and `Id` being optional) (_Note_ : The `HomeController` doesn't exist yet, we'll make it soon)
		- [ ] In the `Startup.cs` file add support for developer exception pages and user friendly error pages.
			- In the `Configure` method before `UseMVC` setup a condition to check if `env` is set to "Developement" using `IsDevelopement`.
				- If Development add `UseBrowserLink`, `UseDeveloperExceptionPage`, and `UseDatabaseErrorPage` to get better detailed error pages.
				- If Not Development Add `UseExceptionHandler` and point it to "Home/Error" to provide a generic "An Error Has Occurred" page. (_Note_ : the Error page doesn't exist yet, we'll make it soon)
	- [ ] Create `HomeController` and "Home"" Views
		- [ ] Create a Generic Welcome View
			- Create a new view "Index" in the "WishList/Views/Home" folder. (you will need to make some of these folders)
            - The "Index" View should contain an `H1` tag welcoming the user.
		- [ ] Create a Generic Error View
			- Create a new view "Error" in the "WishList/Views/Shared" folder. (you will need to make some of these folders)
				- This view should contain a `p` tag sayisc "An Error has occurred. Please Try again."
		- [ ] Create the `HomeController`
			- Create a new Controller "HomeController" inside the "Controllers" folder (you might need to create this folder)
			- Create a new Action `Index` in the `HomeController`
				- This action should have a return type of `ActionResult`.
				- The return statement should return the "Index" view.
			- Create a new Action `Error` in the `HomeController`
				- This action should have a return type of `ActionResult`.
				- The return statement should return the "Error" view.
    - [ ] Create Item Models With EntityFramework Support
        - [ ] Add `EntityFramework` support
            - Create a class `ApplicationDbContext` that inherits the `DbContext` class in the "WishList/Data" folder. (you will need to make some of these folders) (_Note_ : `DbContext` exists in the `Microsoft.EntityFrameWorkCore` namespace)
                - Create the required constructor that accepts a parameter of type `DbContextOptions<ApplicationDbContext>` named `options`.
                - Add the base Invocation after the constructor signature using `: base(options)`.
            - In the `Startup` class's `Configure` method add `EntityFramework` support.
                - Use `AddDbContext<ApplicationDbContext>` to point `EntityFramework` to the application's `DbContext`.
                - Provide the option `UseInMemoryDatabase` to use an in memory database for the time being. 
		- [ ] Create the `Item` model.
			- Create a new class `Item` in the "WishList/Models" folder (You might need to create this folder)
				- This class should contain a public property `Id` of type `int`.
                - This class should contain a public property `Description` of type `string`.
                - The `Description` property should have attributes of `Required` and `StringLength(50)`. (_Note_ : You'll need to add a using statement for `System.CompenentModel.DataAnnotations`.)
			- In the `ApplicationDbContext` class add new public property `Items` of type `DbSet<Item>`.
    - [ ] Create `ItemController` and it's Actions
		- [ ] Create a new Controller `ItemController` inside the `Controllers` folder
            - Create a private readonly property `_context` of type `ApplicationDbContext`. (Do not instantiate it at this time)
            - Create a new constructor that accepts a parameter of type `ApplicationDbContext`
                - This constructor should set `_context` to the provided `ApplicationDbContext` parameter.
			- Create a new Action `Index` in the `ItemController`.
				- This action should have a return type of `ActionResult`.
                - This action should return the item's "Index" view. (_Note_ : The item's Index view doesn't exist yet, we'll make it soon.)
                - This action should provide the "Index" view with a model of type `List<Item>` that contains all items in `_context.Items`.
			- Create a new Action `Create` in the `ItemController`.
                - This action should accept a parameter of type `Item`.
                - This action should have a return type of `ActionResult`.
                - This action should add the provided `Item` to `_context.Items` (_Note_ : Don't forget to `SaveChanges`!)
				- This action should redirect to the `Index` action.
			- Create a new Action `Delete` in the `ItemController`.
                - This action should return a type of `ActionResult`.
                - This action should remove the `Item` with the matching `Id` property from `_context.Items`. (_Note_ : Don't forget to `SaveChanges`!)
                - This action should redirect to the `Index` action.
    - [ ] Create "Item" Views
        - [ ] Add support for Tag Helpers and Layout
            - Create a New View "_ViewImports" in the "WishList/Views" folder.
                - This view should contain `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers`.
            - Create a New View "_ViewStart" in the "WishList/Views" folder.
                - This view should contain `@{ Layout = "_Layout"; }`. (_Note_ : We've provided a very basic layout for you, this layout contains some basic CSS and Jquery.)
		- [ ] Create the Item's "Index" View
			- Create a new View "Index" in the "WishList/Views/Item" folder (You will need to make some of these folders)
				- This view should use a model of `List<Item>`.
                - This view should have an `h1` tag containing "WishList".
                - Inside the `ul` tag should be a razor foreach loop that will iterate through every `Item` in the provided model
                - Each iteration should contain an `li` tag that provides the `Item`'s `Descrition` property followed by an `a` tag.
                - The `a` tag should have the attributes `asp-action` set to "delete", `asp-controller` set to "item", and `asp-route-id` set to the `Item`'s `Id` property with the text of the `a` tag being "delete".
                - In Home's Index view add an `a` tag with attributes `asp-action` set to "index" and `asp-controller` set to "Item" with text "View WishList".
        - [ ] Create a "CreatePartial" Partial View
            - Create a new partial view "CreatePartial" in the "WishList/Views/Item" folder.
                - This view should use a model of `Item`.
                - This view should contain an `h3` tag saying "Add Item to WishList".
                - This view should have a `form` tag containing the attributes `asp-action` set to "create" and `asp-controller` set to "item".
                - Inside the `form` tag create an `input` tag with the attribute `asp-for` set to "description"".
                - Inside the `form` tag create a `span` tag with the attribute `asp-validation-for` set to "descrption".
                - Inside the `form` tag create an `button` tag with the attribute `type` set to "submit" and text "Add Item".
                - In the Item's Index view add the "CreatePartial" view above the `ul` tag.

## What Now?

You've compeleted the tasks of this project, if you want to continue working on this project there will be additional projects added to the ASP.NET Core path that continue where this project left off implimenting authentication, more advanced view and models, as well as providing and consuming data as a webservice.

Otherwise now is a good time to continue on the ASP.NET Core path to expand your understanding of the ASP.NET Core framework or take a look at the Microsoft Azure for Developers path as Azure is a common choice for hosting, scaling, and expanding the functionality of ASP.NET Core applications.