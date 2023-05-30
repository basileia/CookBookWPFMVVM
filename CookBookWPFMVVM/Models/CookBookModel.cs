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
        public BindableCollection<GeneratedMenuModel> GeneratedMenus { get; set; }

        public GeneratedMenuModel LastGeneratedMenu { get; set; }

        public CookBookModel()
        {
            LastGeneratedMenu = new GeneratedMenuModel();
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

        public static GeneratedMenuModel LoadMenuFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContent = File.ReadAllText(filePath);
                GeneratedMenuModel lastGeneratedMenu = JsonConvert.DeserializeObject<GeneratedMenuModel>(fileContent);
                return lastGeneratedMenu;
            }
            return new GeneratedMenuModel();

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

        public static void PutMenusToJson(CookBookModel cookbook, string sourceDirectory, string filePath)
        {
            AuxiliaryMethod.CreateDirectory(sourceDirectory);
            if (!cookbook.LastGeneratedMenu.Equals(null) || File.Exists(filePath))
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer
                    {
                        Formatting = Formatting.Indented
                    };
                    serializer.Serialize(file, cookbook.LastGeneratedMenu);
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
                    if (ingredient.Name.ToLower().Contains(searchedIngredient.ToLower()))
                    {
                        recipes.Add(recipe);
                    }
                }
            }
            return recipes;
        }

        public BindableCollection<RecipeModel> FindRecipesByCategory(string category)
        {
            category = category.ToLower();
            category = char.ToUpper(category[0]) + category.Substring(1);
            return new BindableCollection<RecipeModel>(Recipes.Where(x => x.Categories.Contains(category)).ToList());
        }

        
        public GeneratedMenuModel GenerateRandomMenu()
        {
            Random rnd = new Random();
            BindableCollection<KeyValuePair> weekRandomMenu = new BindableCollection<KeyValuePair>();

            for (int i = 0; i < 5; i++)
            {
                BindableCollection<RecipeModel> oneDayMenu = new BindableCollection<RecipeModel>();
                foreach (CategoryModel category in Enum.GetValues(typeof(CategoryModel)))
                {
                    BindableCollection<RecipeModel> recipesByCategory = FindRecipesByCategory(category.ToString());
                    foreach (RecipeModel recipe in oneDayMenu)
                    {
                        if (recipesByCategory.Contains(recipe))
                        {
                            recipesByCategory.Remove(recipe);
                        }
                    }

                    foreach (var recipes in weekRandomMenu)
                    {
                        foreach (RecipeModel recipe in recipes.Value)
                        {
                            if (recipesByCategory.Contains(recipe))
                            {
                                recipesByCategory.Remove(recipe);
                            }
                        }
                    }
                    if (recipesByCategory.Any())
                    {
                        int randomIndex;
                        randomIndex = rnd.Next(recipesByCategory.Count);
                        oneDayMenu.Add(recipesByCategory[randomIndex]);
                    }
                    else
                    {
                        oneDayMenu.Add(new RecipeModel("Recept s touto kategorií není k dispozici"));
                    }
                }

                KeyValuePair randomMenu = new KeyValuePair
                {
                    Key = i + 1,
                    Value = oneDayMenu,
                };

                weekRandomMenu.Add(randomMenu);
            }

            GeneratedMenuModel weekMenuModel = new GeneratedMenuModel
            {
                DateAndTime = DateTime.Now,
                WeekMenu = weekRandomMenu
            };
            LastGeneratedMenu = weekMenuModel;
            return weekMenuModel;
        }














    }
}
