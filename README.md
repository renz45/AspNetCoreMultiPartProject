# ASP.NET Core WishList Application

The ASP.NET Core WishList Application is designed to allow users to create their own wishlists, and other users to mark that they are buying those items in such a way the owner of the wish list isn't able to see, while other users are able to see. This application is designed using the Model View Controller design pattern.

# Setup the Application

## If you want to use Visual Studio
If you want to use Visual Studio (highly recommended for Windows users) follow the following steps:
-	If you already have Visual Studio installed make sure you have .Net Core installed by running the "Visual Studio Installer" and making sure both "ASP.NET" and ".NET Core cross-platform development" are checked
-	If you need to install visual studio download it at https://www.microsoft.com/net/core#windowsvs2017 On the workloads screen make sure ".NET Core cross-platform development" is checked
-	To run the application simply press the Start Debug button (green arrow) or press F5
-	To run the tests go to "Test" and select "Run All Tests" (you might need to goto "Test" > "Windows" > "Test Explorer" to display the results if you closed the test explorer.)

## If you don't plan to use Visual studio
If you would rather use something other than Visual Studio
-	Install the .Net Core SDK from https://www.microsoft.com/net/download/core once that installation completes you're ready to roll!
-	To run the application go into the WishList project folder and type `dotnet run`
-	To run the tests go into the WishListTests project folder and type `dotnet test /verbosity:quiet` (for OSX users use `dotnet test --verbosity:quiet` instead)

# Project Goals

- Project 1 (Runs through creating an ASP.NET application including adding, configuring, etc middleware, dependency injection, model, view, controller, simple routing, etc)
	- Create the ability to view your wishlist
	- Create the ability add items to your wish list
	- Create the ability to remove items from your wishlist
- Project 2 (Runs through authentication and the necessary supporting functionality)
	- Create the ability to create account
	- Create the ability to login to an account
	- Create the ability to recover lost passwords
	- Create the ability to change your password
	- Associate Wishlists with a user
	- Add authentication to wishlist functionality so only the owner can view / add / delete from a wishlist
- Project 3 (Runs through more advanced view functionality like view templates, sections, layouts, etc. Also expands on controller functionality)
	- Add ability to authorize other users to view your wishlist
	- Add ability to deauthorize other users from viewing your wishlist
	- Unauthorizing a user should wipe out all outstanding reservations
	- Add ability to "reserve" / "unreserve" as item on a wishlist
	- Create template for item for owner that allows add/deleting items (but doesn't show reservation status)
	- Create template for item for authorized user that allows reserving an item
	- Add ability to "unreserve" an item if you're the user who authorized user
- Project  (Runs through request types, returning different data types, http statuses, and basic webservice security)
	- Change project to utilize a webservice (webapi) for it's backend
	- Secure webservice

## Tasks necessary to complete implimentation:

__Note:__ this isn't the only way to accomplish this, however; this is what the project's tests are expecting. Implimenting this in a different way will likely result in being marked as incomplete / incorrect.

### Project 1 Plan ###
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
			- Set to use Local SqlLite database
				- InMemory when running in testing / dev ?
		- [ ] Add Authentication support
			- Add AddIdentity to ConfigureServices.
				- Use EntityFrameworkStorers
				- Use DefaultTokenProviders
			- Add UseAuthentication to Configure.
		- [ ] Setup Error Pages
			- Add IsDevelopment Condition to Configure
				- If Development add UseBrowserLink, UseDeveloperExceptionPage, and UseDatabaseErrorPage
				- If Not Development Add UseExceptionHandler and point it to Home/Error.cshtml
		- [ ] Setup Development Envirornment
			- Add envirornment type to WishList.csproj
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

### Project 2 Plan ###
	- [ ] Setup Basic Authentication
		- [ ] Create "RegisterViewModel"
		
			
