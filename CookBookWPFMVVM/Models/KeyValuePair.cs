using Caliburn.Micro;
using System;

namespace CookBookWPFMVVM.Models
{
    public class KeyValuePair
    {
        public int Key { get; set; }

        public BindableCollection<RecipeModel> Value { get; set; }
    }
}
