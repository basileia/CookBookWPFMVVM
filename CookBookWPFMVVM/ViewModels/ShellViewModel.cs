using Caliburn.Micro;
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
        private BindableCollection<RecipeModel> _recipes = new BindableCollection<RecipeModel>();
        private RecipeModel _selectedRecipe;

        public ShellViewModel()
        {
            DemoData demoData = new DemoData();
            Recipes = new BindableCollection<RecipeModel>(demoData.GetRecipes());
        }

        public BindableCollection<RecipeModel> Recipes
        {
            get { return _recipes; }
            set { _recipes = value; }
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
            ActivateItem(new AddRecipeViewModel());
        }

    }
}
