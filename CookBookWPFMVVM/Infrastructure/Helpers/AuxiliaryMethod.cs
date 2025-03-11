using CookBookWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CookBookWPFMVVM.Infrastructure.Helpers

{
    public class AuxiliaryMethod
    {
        public static string ValidUserNumber(double number)
        {
            if (number <= 0)
            {
                if (number % 1 == 0)
                {
                    return "The number must be an integer greater than zero.";
                }
                else
                {
                    return "The number must be greater than zero.";
                }
            }
            return null; 
        }

        public static string ValidString(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "The text is missing.";
            }
            return null;
        }

        public static string IsNameUnique(string name, List<RecipeModel> existingRecipes)
        {
            if (existingRecipes.Any(recipe => recipe.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return "A recipe with this name already exists.";

            }
            return null;
        }

        public static void CreateDirectory(string sourceDirectory)
        {
            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
            }
        }


    }
}
