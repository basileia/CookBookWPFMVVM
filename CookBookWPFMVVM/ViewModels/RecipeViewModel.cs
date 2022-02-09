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
        public RecipeModel Recipe { get; set; }
        public RecipeViewModel(RecipeModel recipe)
        {
            Recipe = recipe;
            
        }
    }


}

