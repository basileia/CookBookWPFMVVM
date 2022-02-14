using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace CookBookWPFMVVM.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public static string sourceDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CookBook");
        public static string sourceFile = Path.Combine(sourceDirectory, "recipes.json");

        private readonly IWindowManager window = new WindowManager();


        public CookBookModel cookBook { get; set; }
        private string _searchedIngredient;

        public string SearchedIngredient
        {
            get { return _searchedIngredient; }
            set 
            { 
                _searchedIngredient = value;
                NotifyOfPropertyChange(() => SearchedIngredient);
            }
        }


        private RecipeModel _selectedRecipe;

        private BindableCollection<RecipeModel> _recipesToShow;
        
        public BindableCollection<RecipeModel> RecipesToShow
        {
            get { return _recipesToShow; }
            set
            {
                _recipesToShow = value;
                NotifyOfPropertyChange(() => RecipesToShow);
            }
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
        public ShellViewModel()
        {
            cookBook = new CookBookModel();
            cookBook.Recipes = CookBookModel.LoadRecipesFromJson(sourceFile);
            LoadRecipes(1);
        }

        public void LoadAddRecipePage()
        {
            ActivateItem(new AddRecipeViewModel(cookBook));
        }
        public BindableCollection<RecipeModel> SearchRecipesByIngredient()
        {
            BindableCollection<RecipeModel> recipes = new BindableCollection<RecipeModel>();
            foreach (RecipeModel recipe in  cookBook.Recipes)
            {
                foreach (IngredientModel ingredient in recipe.IngredientsList)
                {
                    if (ingredient.Name.ToLower() == SearchedIngredient.ToLower())
                    {
                        recipes.Add(recipe);
                    }
                }
            }
            
            if (recipes.Any())
            {               
                return recipes;
            }
            else
            {
                MessageBox.Show("There is no recipe for this ingredient");
            }

            return cookBook.Recipes;
        }

        public void LoadRecipes(int i = 0)
        {
            if (i == 1)
            {
                RecipesToShow = cookBook.Recipes;
            }
            else
            {
                RecipesToShow = SearchRecipesByIngredient();
                SearchedIngredient = "";
            }
            
        }
        
        // Button for show all recipes
        // comboBox search by ingredient/category ?

    }
}
