using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using CookBookWPFMVVM.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CookBookWPFMVVM.ViewModels
{
    public class AddRecipeViewModel : Screen
    {
        CookBookModel cookBook = new CookBookModel();
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private int _numberOfServings;

        public int NumberOfServings
        {
            get { return _numberOfServings; }
            set
            {
                _numberOfServings = value;
                NotifyOfPropertyChange(() => NumberOfServings);
            }
        }

        private string _preparation;

        public string Preparation
        {
            get { return _preparation; }
            set
            {
                _preparation = value;
                NotifyOfPropertyChange(() => Preparation);
            }
        }

        private BindableCollection<IngredientModel> _ingredients = new BindableCollection<IngredientModel>();

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

        private string _selectedCategory;

        private BindableCollection<string> _categories = new BindableCollection<string>();
        public BindableCollection<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyOfPropertyChange(() => Categories);
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

        private string _selectedCategoryToRemove;
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


        public BindableCollection<string> AllCategories { get; set; }

        readonly IWindowManager manager = new WindowManager();
        public void AddIngredientWindow()
        {

            manager.ShowWindow(new AddIngredientViewModel(Ingredients), null, null);
        }

        public AddRecipeViewModel(CookBookModel cookbook)
        {
            cookBook = cookbook;
            AllCategories = new BindableCollection<string>(Enum.GetNames(typeof(CategoryModel)).ToList());
        }

        public void AddRecipe()
        {
            if (AuxiliaryMethod.ValidString(Name) && AuxiliaryMethod.ValidUserNumber(NumberOfServings) && AuxiliaryMethod.ValidString(Preparation))
            {
                cookBook.AddRecipeToCookBook(Name, NumberOfServings, Preparation, Ingredients, Categories);

                Name = "";
                Preparation = "";
                NumberOfServings = 0;
                Ingredients = new BindableCollection<IngredientModel>();
                Categories = new BindableCollection<string>();
            }
        }

 
    }
}
