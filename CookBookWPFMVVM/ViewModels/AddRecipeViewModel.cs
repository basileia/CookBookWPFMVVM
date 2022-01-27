using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using CookBookWPFMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public int NumberOfServings { get; set; }
        public string Preparation { get; set; }

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
            }
        }
    }
}
