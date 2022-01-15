using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM.Models
{
    public class CookBookModel
    {
        public BindableCollection<RecipeModel> Recipes { get; set; }

        public CookBookModel()
        {
            
        }
        
        //public void AddRecipeToCookBook(string name, int numberOfervings, string preparation, List<IngredientModel> ingredients, List<CategoryModel> categories)
        //{
        //    RecipeModel recipe = new RecipeModel(name)
        //    {
        //        NumberOfServings = numberOfervings,
        //        Preparation = preparation,
        //        Categories = categories,
        //        IngredientsList = ingredients
        //    };

        //    Recipes.Add(recipe);
        //}

        public void AddRecipeToCookBook(string name)
        {
            RecipeModel recipe = new RecipeModel(name);
            Recipes.Add(recipe);
        }
    }
}
