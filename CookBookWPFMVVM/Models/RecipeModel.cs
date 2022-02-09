using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM.Models
{
    public class RecipeModel
    {
        public string Name { get; set; }
        public int NumberOfServings { get; set; }
        public string Preparation { get; set; }
        public BindableCollection<IngredientModel> IngredientsList { get; set; } = new BindableCollection<IngredientModel>();
        public BindableCollection<string> Categories { get; set; } = new BindableCollection<string>();

        public RecipeModel(string name)
        {
            Name = name;
        }

          
        
    }
}
