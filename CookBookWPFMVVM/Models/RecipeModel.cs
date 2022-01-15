﻿using System;
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
        public List<IngredientModel> IngredientsList { get; set; } = new List<IngredientModel>();
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();

        public RecipeModel(string name)
        {
            Name = name;
        }
    
        
    }
}