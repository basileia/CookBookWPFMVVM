using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM.ViewModels
{
    public class GenerateMenuViewModel : Screen
    {
        CookBookModel cookBook = new CookBookModel();

        public GenerateMenuViewModel(CookBookModel cookbook)
        {
            cookBook = cookbook;
        }
    }
}
