# Part 3
## Instructions
### To compile and run the Recipe App software, please follow these steps:
1. Ensure that you have the necessary software installed:
    + Microsoft Visual Studio (preferably the latest version)
    + .NET Framework (version 4.8 or later)
2. Clone or download the source code from the repository.
3. Open the solution file (**RecipeApp.sln**) in Microsoft Visual Studio.
4. Build the solution to compile the code. If any NuGet package dependencies are missing, restore them using the NuGet Package Manager.
5. Set the startup project to **Part 3** if it's not already selected.
6. Run the application by pressing F5 or clicking on the "Start" button in Visual Studio.
7. The Recipe App window will appear, displaying the sample recipes. You can use the provided filter options to search for recipes based on         ingredients, food groups, and maximum calories.
8. To clear the filters, click the "Clear Filters" button.
9. Select a recipe from the list to view more details or perform further actions as per your application requirements.

## Description of Changes
### In this version of the Recipe App, the following changes were made:
- Added sample data: Upon application startup, sample recipes are now added to the recipe list. This provides a starting point for users to see how the application works and interact with the recipes.
- Updated the MainWindow constructor: The constructor now initializes the recipe list, adds sample recipes using the AddSampleData method, and sets the item source for the recipe list (**lstRecipes.ItemsSource = recipes**).
- Modified event handlers: The event handlers for filtering recipes based on ingredient, food group, and maximum calories were updated to correctly filter the recipes based on user input.
- Added a Clear Filters button: A new button, "Clear Filters," was added to reset all filter options and display the full list of recipes.

These changes improve the usability of the Recipe App by providing sample data, enhancing the filtering functionality, and allowing users to easily clear the applied filters.
