using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CookBookWPFMVVM
{
    public class AuxiliaryMethod
    {
        public static bool ValidUserNumber(int number)
        {
            
            if (number <= 0)
            {
                MessageBox.Show("The number must be greater than zero");
                return false;
            }
            return true;
        }

        public static bool ValidString(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("The text is missing");
                return false;
            }
            return true;
        }

  
    }
}
