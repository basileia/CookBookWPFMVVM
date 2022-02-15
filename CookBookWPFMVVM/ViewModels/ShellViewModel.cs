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

        public BindableCollection<string> SearchOptions
        {
            get
            {
                return new BindableCollection<string> { "Ingredient", "Category" };
            }
        }

        private string _selectedSearchOption;
        public string SelectedSearchOption
        {
            get { return _selectedSearchOption; }
            set
            {
                _selectedSearchOption = value;
                NotifyOfPropertyChange(() => SelectedSearchOption);
            }
        }


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
            LoadAllRecipes();
        }

        public void LoadAddRecipePage()
        {
            ActivateItem(new AddRecipeViewModel(cookBook));
        }
       
        public void LoadRecipesByIngredient()
        {
            RecipesToShow = cookBook.SearchRecipesByIngredient(cookBook, SearchedIngredient);
            
            if (!RecipesToShow.Any())
            {
                MessageBox.Show("There is no recipe for this ingredient");
                RecipesToShow = cookBook.Recipes;
            }
            SearchedIngredient = "";
        }
        
        public void LoadAllRecipes()
        {
            RecipesToShow = cookBook.Recipes;
        }

        // search by selectedSearchOption

    }
}
