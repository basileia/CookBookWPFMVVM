using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM.ViewModels
{
    public class GenerateMenuViewModel : Screen
    {
        CookBookModel cookBook = new CookBookModel();
        

        public BindableCollection<BindableCollection<RecipeModel>> RecipesToShow
        {
            get { return _recipesToShow; }
            set
            {
                _recipesToShow = value;
                NotifyOfPropertyChange(() => RecipesToShow);
                
                
            }
        }

        public GenerateMenuViewModel(CookBookModel cookbook, BindableCollection<BindableCollection<RecipeModel>> generatedMenu)
        {
            cookBook = cookbook;
            RecipesToShow = generatedMenu;
        }

        private BindableCollection<BindableCollection<RecipeModel>> _recipesToShow;
       
    }

}
