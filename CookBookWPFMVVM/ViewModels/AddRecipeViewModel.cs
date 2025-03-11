using Caliburn.Micro;
using CookBookWPFMVVM.Infrastructure.Helpers;
using CookBookWPFMVVM.Models;
using System;
using System.Linq;
using System.Windows;

namespace CookBookWPFMVVM.ViewModels
{
    public class AddRecipeViewModel : BaseViewModel
    {        
        private readonly CookBookModel cookBook = new CookBookModel();
        private readonly IWindowManager manager = new WindowManager();
        
        private string _name;
        private int _numberOfServings;
        private string _preparation;
        private string _selectedCategory;
        private string _selectedCategoryToRemove;
        private BindableCollection<IngredientModel> _ingredients = new BindableCollection<IngredientModel>();
        private BindableCollection<string> _categories = new BindableCollection<string>();
        public AddRecipeViewModel(CookBookModel cookbook)
        {
            cookBook = cookbook;
            AllCategories = new BindableCollection<string>(Enum.GetNames(typeof(CategoryModel)).ToList());
        }
        public BindableCollection<string> AllCategories { get; set; }
        public BindableCollection<IngredientModel> Ingredients
        {
            get { return _ingredients; }
            set
            {
                if (Equals(value, _ingredients)) return;
                _ingredients = value;
                NotifyOfPropertyChange(() => Ingredients);
            }
        }
        public BindableCollection<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                ValidateProperty("Name", Name, AuxiliaryMethod.ValidString);
            }
        }
        public int NumberOfServings
        {
            get { return _numberOfServings; }
            set
            {
                _numberOfServings = value;
                NotifyOfPropertyChange(() => NumberOfServings);
                ValidateProperty("NumberOfServings", (double)NumberOfServings, AuxiliaryMethod.ValidUserNumber);
            }
        }
        public string Preparation
        {
            get { return _preparation; }
            set
            {
                _preparation = value;
                NotifyOfPropertyChange(() => Preparation);
                ValidateProperty("Preparation", Preparation, AuxiliaryMethod.ValidString);
            }
        }
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;

                if (!Categories.Contains(_selectedCategory))
                {
                    Categories.Add(_selectedCategory);
                }
                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }
        public string SelectedCategoryToRemove
        {
            get { return _selectedCategoryToRemove; }
            set
            {
                _selectedCategoryToRemove = value;
                Categories.Remove(_selectedCategoryToRemove);
                NotifyOfPropertyChange(() => SelectedCategoryToRemove);
            }
        }        

        public void AddIngredientWindow()
        {

            manager.ShowWindow(new AddIngredientViewModel(Ingredients), null, null);
        }
        
        public void AddRecipe() //name unique doplnit
        {
            if (!HasErrors)
            {
                cookBook.AddRecipeToCookBook(Name, NumberOfServings, Preparation, Ingredients, Categories);
                CookBookModel.PutRecipesToJson(cookBook, ShellViewModel.sourceDirectory, ShellViewModel.sourceFileRecipes);

                Name = "";
                Preparation = "";
                NumberOfServings = 0;
                Ingredients = new BindableCollection<IngredientModel>();
                Categories = new BindableCollection<string>();
            }
            else
            {
                MessageBox.Show("Please correct the errors before adding the recipe.");
            }
        }
    }
}
