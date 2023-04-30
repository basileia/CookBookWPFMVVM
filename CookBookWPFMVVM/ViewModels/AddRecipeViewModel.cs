using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using System;
using System.Linq;
using System.Windows;

namespace CookBookWPFMVVM.ViewModels
{
    public class AddRecipeViewModel : Screen
    {
        
        CookBookModel cookBook = new CookBookModel();
        readonly IWindowManager manager = new WindowManager();
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
            }
        }
        public int NumberOfServings
        {
            get { return _numberOfServings; }
            set
            {
                _numberOfServings = value;
                NotifyOfPropertyChange(() => NumberOfServings);
            }
        }
        public string Preparation
        {
            get { return _preparation; }
            set
            {
                _preparation = value;
                NotifyOfPropertyChange(() => Preparation);
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

        private BindableCollection<IngredientModel> _ingredients = new BindableCollection<IngredientModel>();
        private BindableCollection<string> _categories = new BindableCollection<string>();
        private string _name;
        private int _numberOfServings;
        private string _preparation;
        private string _selectedCategory;
        private string _selectedCategoryToRemove;
  
        
        public void AddIngredientWindow()
        {

            manager.ShowWindow(new AddIngredientViewModel(Ingredients), null, null);
        }
        
        public void AddRecipe()
        {
            if (AuxiliaryMethod.ValidString(Name) && AuxiliaryMethod.ValidUserNumber(NumberOfServings) && AuxiliaryMethod.ValidString(Preparation))
            {
                if (cookBook.Recipes.Any(p => p.Name.ToLower() == Name.ToLower()))
                {
                    MessageBox.Show("A recipe with this name already exists");
                }
                else
                {
                    cookBook.AddRecipeToCookBook(Name, NumberOfServings, Preparation, Ingredients, Categories);
                    CookBookModel.PutRecipesToJson(cookBook, ShellViewModel.sourceDirectory, ShellViewModel.sourceFileRecipes);
                    
                    Name = "";
                    Preparation = "";
                    NumberOfServings = 0;
                    Ingredients = new BindableCollection<IngredientModel>();
                    Categories = new BindableCollection<string>();
                }
            }
        }
    }
}
