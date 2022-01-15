using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using CookBookWPFMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CookBookWPFMVVM.ViewModels
{
    public class AddRecipeViewModel : Screen
    {
        CookBookModel cookBook = new CookBookModel();
        public AddRecipeViewModel(CookBookModel cookbook)
        {
            cookBook = cookbook;
        }

        public void AddRecipe()  //AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            //string name = nameTextBox.Name;
            cookBook.AddRecipeToCookBook("Polévka");

        }

    }
}
