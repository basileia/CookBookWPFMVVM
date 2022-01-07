using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM.Models
{
    public class IngredientModel
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public IngredientModel(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity <= 0 ? 0 : quantity;
            Unit = unit;
        }

        public IngredientModel() { }
    }
}
