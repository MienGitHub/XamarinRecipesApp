using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinRecipesApp.Views;

namespace XamarinRecipesApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RecipeEntryPage), typeof(RecipeEntryPage));
        }
    }
}
