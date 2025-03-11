using Caliburn.Micro;
using System.ComponentModel.DataAnnotations;

namespace CookBookWPFMVVM.Models
{
    public class RecipeModel
    {
        [Required(ErrorMessage = "Name is required.")]
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
