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
        private string _searchedItem;

        public string SearchedItem
        {
            get { return _searchedItem; }
            set 
            { 
                _searchedItem = value;
                NotifyOfPropertyChange(() => SearchedItem);
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
       
        public void LoadRecipesBySearchedOption()
        {
            if (SelectedSearchOption == "Ingredient")
            {
                
                RecipesToShow = cookBook.SearchRecipesByIngredient(cookBook, SearchedItem);
                
                if (!RecipesToShow.Any())
                {
                    MessageBox.Show("There is no recipe for this ingredient");
                    RecipesToShow = cookBook.Recipes;
                }
            }
            else if (SelectedSearchOption == "Category")
            {
                RecipesToShow = cookBook.FindRecipesByCategory(SearchedItem);
                if (!RecipesToShow.Any())
                {
                    MessageBox.Show("There is no recipe for this category");
                    RecipesToShow = cookBook.Recipes;
                }
            }
            else
            {
                MessageBox.Show("Please choose searched option");
            }
            SearchedItem = "";
        }
        
        public void LoadAllRecipes()
        {
            RecipesToShow = SortRecipes(cookBook.Recipes);

        }

        private static BindableCollection<RecipeModel> SortRecipes(BindableCollection<RecipeModel> recipesToSort)
        {
            BindableCollection<RecipeModel> temp;
            temp = new BindableCollection<RecipeModel>(recipesToSort.OrderBy(p => p.Name));
            recipesToSort.Clear();
            foreach (RecipeModel j in temp) recipesToSort.Add(j);
            return recipesToSort;
        }

    }
}
