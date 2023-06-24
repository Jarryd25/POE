﻿using System;
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

    public class Recipe
    {
        private List<Ingredient> ingredients; // List to store the ingredients
        private List<string> steps; // List to store the steps
        public string Name { get; set; } // Name of the recipe

    }

    public partial class MainWindow : Window
    {
        private List<Recipe> recipes; // List to store recipes
        private List<Recipe> filteredRecipes; // List to store filtered recipes
        public MainWindow()
        {
            InitializeComponent();

            // Initialise the lists
            recipes = new List<Recipe>();
            filteredRecipes = new List<Recipe>();

            // Sample recipes
            Recipe recipe1 = new Recipe("Recipe 1");
            recipe1.AddIngredient(new Ingredient("Ingredient 1", 2, "Units", 100, "Group 1"));
            recipe1.AddIngredient(new Ingredient("Ingredient 2", 1, "Cups", 150, "Group 2"));
            recipe1.AddStep("Step 1");
            recipe1.AddStep("Step 2");
            recipes.Add(recipe1);

            Recipe recipe2 = new Recipe("Recipe 2");
            recipe2.AddIngredient(new Ingredient("Ingredient 3", 3, "Units", 200, "Group 1"));
            recipe2.AddIngredient(new Ingredient("Ingredient 4", 2, "Cups", 250, "Group 3"));
            recipe2.AddStep("Step 1");
            recipe2.AddStep("Step 2");
            recipes.Add(recipe2);

            // Display all recipes initially
            lstRecipes.ItemsSource = recipes;
        }

        // Event handler for ingredient filter textbox
        private void TxtIngredientFilter_TextChanged(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }
        // Event handler for food group filter combobox
        private void CmbFoodGroupFilter_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }
        // Event handler for max calories filter textbox
        private void TxtMaxCaloriesFilter_TextChanged(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        // Method to apply the filters
        private void ApplyFilters()
        {
            
        }
    }
}
