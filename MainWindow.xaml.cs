using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Part_3
{
    // Define a class for an ingredient
    class Ingredient
    {
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string Unit { get; set; } // Unit of measurement of the ingredient
        public int Calories { get; set; } // Number of calories in the ingredient
        public string FoodGroup { get; set; } // Food group that the ingredient belongs to

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }

    // Define a class for a recipe
    class Recipe
    {
        public List<Ingredient> ingredients; // List to store the ingredients
        private List<string> steps; // List to store the steps
        public string Name { get; set; } // Name of the recipe

        // Constructor to initialize the recipe and its properties
        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        // Method to add a step to the recipe
        public void AddStep(string step)
        {
            steps.Add(step);
        }


        // Method to calculate and display the total calories of the recipe
        public void DisplayTotalCalories()
        {
            int totalCalories = ingredients.Sum(ingredient => ingredient.Calories);
            MessageBox.Show($"Total calories: {totalCalories}");
            if (totalCalories > 300)
            {
                MessageBox.Show("Warning: This recipe exceeds 300 calories.");
            }
        }

        // Method to display the recipe in a neat format
        public void Display()
        {
            MessageBox.Show($"Recipe: {Name}");

            MessageBox.Show("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                MessageBox.Show($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} " +
                                $"({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            MessageBox.Show("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                MessageBox.Show($"{i + 1}. {steps[i]}");
            }
        }
    }

    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>(); // List to store recipes
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for filtering recipes based on ingredient
        private void TxtIngredientFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string ingredientFilter = IngredientFilter.Text.ToLower();
            List<Recipe> filteredRecipes = recipes.Where(recipe => recipe.ingredients.Any(ingredient => ingredient.Name.ToLower().Contains(ingredientFilter))).ToList();

            lstRecipes.ItemsSource = filteredRecipes;
        }

        // Event handler for filtering recipes based on food group
        private void CmbFoodGroupFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFoodGroup = (cmbFoodGroupFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
            List<Recipe> filteredRecipes;

            if (selectedFoodGroup == "All Food Groups")
            {
                filteredRecipes = recipes;
            }
            else
            {
                filteredRecipes = recipes.Where(recipe =>
                    recipe.ingredients.Any(ingredient => ingredient.FoodGroup == selectedFoodGroup))
                    .ToList();
            }

            lstRecipes.ItemsSource = filteredRecipes;
        }

        // Event handler for filtering recipes based on maximum calories
        private void TxtMaxCaloriesFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(txtMaxCaloriesFilter.Text, out int maxCalories))
            {
                List<Recipe> filteredRecipes = recipes.Where(recipe =>
                    recipe.ingredients.Sum(ingredient => ingredient.Calories) <= maxCalories)
                    .ToList();

                lstRecipes.ItemsSource = filteredRecipes;
            }
        }

        // Event handler to clear all filters and show all recipes
        private void BtnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            lstRecipes.ItemsSource = recipes;
            IngredientFilter.Text = string.Empty;
            cmbFoodGroupFilter.SelectedItem = cmbFoodGroupFilter.Items[0];
            txtMaxCaloriesFilter.Text = string.Empty;
        }
    }
}
