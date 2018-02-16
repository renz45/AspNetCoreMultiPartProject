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
	- [ ] Add Middleware/Configuration to Startup.cs
		- [ ] Add MVC support
			- Add AddMVC to ConfigureServices.
			- Add UseMVC to Configure.
				- Provide UseMVC with default Controller/Action/Id Route (defaulting to Home/Index)
		- [ ] Add EntityFramework support
			- Create class ApplicationDbContext that inherits DbContext
				- Create the required constructor that accepts DbContextOptions<ApplicationDbContext>
				- Add the required Base Invokation
			- Add DbContext to ConfigureServices.
			    - Set to use InMemoryDatabase
		- [ ] Setup Error Pages
			- Add IsDevelopment Condition to Configure
				- If Development add UseBrowserLink, UseDeveloperExceptionPage, and UseDatabaseErrorPage
				- If Not Development Add UseExceptionHandler and point it to Home/Error.cshtml
		- [ ] Setup Development Environment
			- Add environment type to WishList.csproj
                - Set it to "Development"
	- [ ] Add HomeController and Views
		- [ ] Add Generic Welcome View
			- Create a new Folder "Home" in the "Views" folder
			- Create a new View "Index" in the "Home" folder
				- This view should simply welcome the user to the WishList Application.
		- [ ] Add Error View
			- Create a new Folder "Views"
			- Create a new Folder "Shared" in the "Views" folder
			- Create a new View in the Shared Folder named "Error"
				- This view should simply say "An Error has occurred. Please Try again."
		- [ ] Create HomeController
			- Create a new Folder "Controllers"
			- Create a new Controller "HomeController" inside the "Controllers" folder
			- Create a new Action "Index" in the HomeController
				- This action should return an ActionResult
				- The return statement should be a View
			- Create a new Action "Error" in the HomeController
				- This action should return an ActionResult
				- The return statement should be a View
		- [ ] Create a new Folder "Models"
			- Create a new class "Item" in folder "Models"
				- This class should have an public int "Id" and a public string "Description"
			- Add the "Item" class to ApplicationDbContext
		- [ ] Create a new Controller "WishListController" inside the "Controllers" folder
			- Create a new Action "Index" in the WishListController
				- This action should select get all Items and return them to the view
			- Create a new Action "Create" in the WishListController
				- This action should add a new Item to Items then redirect to the Index action
			- Create a new Action "Delete" in the WishListController
				- This action should remove an Item with the matching Id then redirect to the Index Action
		- [ ] Create a new folder "WishList" in the Views folder
			- Create a new View "Index" in the WishList folder
				- This view should accept a model of List<Item>
				- It should use a foreach loop to add rows that will have the Item description with a link to the delete action next to it
				- It should have a form containing a description text box and an submit button
        - [ ] Add a Link to the WishList's Index action to the Home Index view.
            - Add link to the WishList's Index action below the p tag.

## What Now?

You've compeleted the tasks of this project, if you want to continue working on this project there will be additional projects added to the ASP.NET Core path that continue where this project left off implimenting authentication, more advanced view and models, as well as providing and consuming data as a webservice.

Otherwise now is a good time to continue on the ASP.NET Core path to expand your understanding of the ASP.NET Core framework or take a look at the Microsoft Azure for Developers path as Azure is a common choice for hosting, scaling, and expanding the functionality of ASP.NET Core applications.