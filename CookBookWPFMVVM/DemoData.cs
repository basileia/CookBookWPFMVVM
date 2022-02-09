using CookBookWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM
{
    public class DemoData
    {
        Random rnd = new Random();

        string[] recipeNames = new string[] { "Kokosová roláda", "Kulajda", "Míchaná vajíčka", "Vařená vejce" };
        string preparation = "Připravte";

        string[] ingredientNames = new string[] { "vejce", "mouka" };
        string unit = "ks";
        Array categories = Enum.GetValues(typeof(CategoryModel));
        


        //CategoryModel category = (CategoryModel) Enum.Parse(typeof(CategoryModel), "Snídaně");

        public List<RecipeModel> GetRecipes()
        {
            List<RecipeModel> output = new List<RecipeModel>();
            for (int i = 0; i < 3; i++)
            {
                output.Add(GetRecipe());
            }
            return output;
        }

        private RecipeModel GetRecipe()
        {
            string recipeName = GetRandomItem(recipeNames);
            RecipeModel output = new RecipeModel(recipeName);
            output.NumberOfServings = rnd.Next(1, 5);
            output.Preparation = preparation;
            //output.Category = category;

            for (int i = 0; i < 2; i++)
            {
                output.IngredientsList.Add(GetIngredient());
            }
  
            for (int i = 0; i < 2; i++)
            {
                output.Categories.Add(GetCategory());
            }
            
            return output;
        }

        private T GetRandomItem<T>(T[] data)
        {
            return data[rnd.Next(0, data.Length)];
        }

        private IngredientModel GetIngredient()
        {
            IngredientModel output = new IngredientModel();
            output.Name = GetRandomItem(ingredientNames);
            output.Quantity = rnd.Next(1, 5);
            output.Unit = unit;

            return output;
        }

        private string GetCategory()
        {
            CategoryModel output = new CategoryModel();
            output = (CategoryModel)categories.GetValue(rnd.Next(categories.Length));
            return output.ToString();
        }

    }
}
