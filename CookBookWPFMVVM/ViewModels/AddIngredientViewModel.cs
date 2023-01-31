using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM.ViewModels
{
    class AddIngredientViewModel : Screen
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        readonly BindableCollection<IngredientModel> Ingredients = new BindableCollection<IngredientModel>();
        public AddIngredientViewModel(BindableCollection<IngredientModel> ingredients)
        {
            Ingredients = ingredients;
        }
        public void AddIngredientToList()
        {
            if (AuxiliaryMethod.ValidString(Name) && AuxiliaryMethod.ValidUserNumber(Quantity) && AuxiliaryMethod.ValidString(Unit))
            {
                IngredientModel ingredient = new IngredientModel()
                {
                    Name = Name,
                    Quantity = Quantity,
                    Unit = Unit
                };
                Ingredients.Add(ingredient);
                TryClose();
            }
                        
        }

    }
}
