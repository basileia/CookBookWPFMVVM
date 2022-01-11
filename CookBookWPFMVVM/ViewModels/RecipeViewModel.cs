using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM.ViewModels
{
    public class RecipeViewModel : Screen
    {
        public string Name { get; set; }
        public int NumberOfServings { get; set; }
        
        public BindableCollection<IngredientModel> IngredientsList { get; set; }
        public string Preparation { get; set; }
        
        public RecipeViewModel(RecipeModel recipe)
        {
            Name = recipe.Name;
            NumberOfServings = recipe.NumberOfServings;
            IngredientsList = new BindableCollection<IngredientModel>(recipe.IngredientsList);
            Preparation = recipe.Preparation;
        }
    }
}

