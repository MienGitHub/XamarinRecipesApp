using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRecipesApp.Models;

namespace XamarinRecipesApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class RecipeEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadRecipe(value);
            }
        }

        public RecipeEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Recipe.
            BindingContext = new Recipe();
        }

        async void LoadRecipe(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the recipe and set it as the BindingContext of the page.
                Recipe recipe = await App.Database.GetRecipeAsync(id);
                BindingContext = recipe;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load recipe.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            recipe.Date = DateTime.UtcNow;
            // CHANGES: + the string lmao
            if (!string.IsNullOrWhiteSpace(recipe.TextA + recipe.TextB + recipe.TextC + recipe.TextD))
            {
                await App.Database.SaveRecipeAsync(recipe);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            await App.Database.DeleteRecipeAsync(recipe);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}