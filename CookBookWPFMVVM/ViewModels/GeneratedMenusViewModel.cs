using Caliburn.Micro;
using CookBookWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM.ViewModels
{
    public class GeneratedMenusViewModel
    {

        public GeneratedMenusViewModel(BindableCollection<GeneratedMenuModel> generatedMenus)
        {
            GeneratedMenus = generatedMenus;
        }

        public BindableCollection<GeneratedMenuModel> GeneratedMenus { get; set; }

    }
}
