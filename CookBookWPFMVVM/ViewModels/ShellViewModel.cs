﻿using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace CookBookWPFMVVM.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public static string sourceDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CookBook");
        public static string sourceFile = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CookBook"), "recipes.json");
        
        private RecipeModel _selectedRecipe;
        public CookBookModel cookBook { get; set; }
        
        public ShellViewModel()
        {
            cookBook = new CookBookModel();
            cookBook.Recipes = CookBookModel.LoadRecipesFromJson(sourceFile);
        }

        public RecipeModel SelectedRecipe
        {
            get { return _selectedRecipe; }
            set 
            {
                _selectedRecipe = value;
                if (_selectedRecipe != null)
                {
                    ActivateItem(new RecipeViewModel(_selectedRecipe));
                }
                NotifyOfPropertyChange(() => SelectedRecipe);
                
            }
        }

        public void LoadAddRecipePage()
        {
            ActivateItem(new AddRecipeViewModel(cookBook));
        }

        


    }
}
