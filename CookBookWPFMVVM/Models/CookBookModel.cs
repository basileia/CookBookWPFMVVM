using Caliburn.Micro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        
        public void AddRecipeToCookBook(string name, int numberOfServings, string preparation, BindableCollection<IngredientModel> ingredients, BindableCollection<string> categories)
        {

            RecipeModel recipe = new RecipeModel(name)
            {
                NumberOfServings = numberOfServings,
                Preparation = preparation,
                IngredientsList = ingredients,
                Categories = categories,
            };

            Recipes.Add(recipe);
        }

        public static BindableCollection<RecipeModel> LoadRecipesFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContent = File.ReadAllText(filePath);
                List<RecipeModel> recipesList = JsonConvert.DeserializeObject<List<RecipeModel>>(fileContent);
                BindableCollection<RecipeModel> recipes = new BindableCollection<RecipeModel>();
                recipesList.ForEach(x => recipes.Add(x));
                return recipes;
            }
            return new BindableCollection<RecipeModel>();
            
        }

        public static void PutRecipesToJson(CookBookModel cookbook, string sourceDirectory, string filePath)
        {
            AuxiliaryMethod.CreateDirectory(sourceDirectory);
            if (cookbook.Recipes.Any() || File.Exists(filePath))
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer
                    {
                        Formatting = Formatting.Indented
                    };
                    serializer.Serialize(file, cookbook.Recipes);
                }
            }
        }

        public BindableCollection<RecipeModel> SearchRecipesByIngredient(CookBookModel cookbook, string searchedIngredient)
        {
            BindableCollection<RecipeModel> recipes = new BindableCollection<RecipeModel>();
            foreach (RecipeModel recipe in cookbook.Recipes)
            {
                foreach (IngredientModel ingredient in recipe.IngredientsList)
                {
                    if (ingredient.Name.ToLower() == searchedIngredient.ToLower())
                    {
                        recipes.Add(recipe);
                    }
                }
            }
            return recipes;
        }
    }
}
