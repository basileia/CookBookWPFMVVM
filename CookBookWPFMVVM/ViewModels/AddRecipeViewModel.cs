using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using CookBookWPFMVVM.Views;
using System;
using System.Collections.Generic;
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

        readonly IWindowManager manager = new WindowManager();
        public void AddIngredientWindow()
        {
            manager.ShowWindow(new AddIngredientViewModel(), null, null);
        }

        public AddRecipeViewModel(CookBookModel cookbook)
        {
            cookBook = cookbook;
        }

        public void AddRecipe()
        {
            if (AuxiliaryMethod.ValidString(Name) && AuxiliaryMethod.ValidUserNumber(NumberOfServings) && AuxiliaryMethod.ValidString(Preparation))
            {
                cookBook.AddRecipeToCookBook(Name, NumberOfServings, Preparation);
                Name = "";
                Preparation = "";
                NumberOfServings = 0;
            }
        }

 
    }
}
