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
        private RecipeModel _selectedRecipe;
        public CookBookModel cookBook { get; set; }
        
        public ShellViewModel()
        {
            DemoData demoData = new DemoData();
            cookBook = new CookBookModel
            {
                Recipes = new BindableCollection<RecipeModel>(demoData.GetRecipes())
            };
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
