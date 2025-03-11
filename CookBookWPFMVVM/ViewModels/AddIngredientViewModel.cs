using Caliburn.Micro;
using CookBookWPFMVVM.Infrastructure.Helpers;
using CookBookWPFMVVM.Models;

namespace CookBookWPFMVVM.ViewModels
{
    class AddIngredientViewModel : BaseViewModel
    {
        private string _name;
        private double _quantity;
        private string _unit;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                ValidateProperty(nameof(Name), _name, AuxiliaryMethod.ValidString);
            }
        }

        public double Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                NotifyOfPropertyChange(() => Quantity);
                ValidateProperty(nameof(Quantity), _quantity, AuxiliaryMethod.ValidUserNumber);
            }
        }

        public string Unit
        {
            get => _unit;
            set
            {
                _unit = value;
                NotifyOfPropertyChange(() => Unit);
                ValidateProperty(nameof(Unit), _unit, AuxiliaryMethod.ValidString);
            }
        }

        private readonly BindableCollection<IngredientModel> _ingredients;

        public AddIngredientViewModel(BindableCollection<IngredientModel> ingredients)
        {
            _ingredients = ingredients;
        }
       
        public void AddIngredientToList()
        {
            if (HasErrors) return; 

            var ingredient = new IngredientModel
            {
                Name = Name,
                Quantity = Quantity,
                Unit = Unit
            };

            _ingredients.Add(ingredient);
            TryClose();                         
        }   
    }
}
