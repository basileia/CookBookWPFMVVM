using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CookBookWPFMVVM.Infrastructure.Helpers

{
    public class AuxiliaryMethod
    {
        public static bool ValidUserNumber(double number)
        {
            
            if (number <= 0)
            {
                if (number % 1 == 0)
                {
                    MessageBox.Show("The number must be an integer greater than zero");
                }

                else
                {
                    MessageBox.Show("The number must be greater than zero");
                }
                
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

        public static void CreateDirectory(string sourceDirectory)
        {
            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
            }
        }


    }
}
