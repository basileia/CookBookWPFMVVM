using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookWPFMVVM.Models
{
    public class KeyValuePair
    {
        public int Key { get; set; }

        public BindableCollection<RecipeModel> Value { get; set; }
    }
}
