﻿using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRecipesApp.Data;
using XamarinRecipesApp.Views;

namespace XamarinRecipesApp
{
    public partial class App : Application
    {
        static RecipeDatabase database;

        // Create the database connection as a singleton.
        public static RecipeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RecipeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Recipes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
