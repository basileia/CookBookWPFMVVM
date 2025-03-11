using Caliburn.Micro;
using CookBookWPFMVVM.Models;

namespace CookBookWPFMVVM.ViewModels
{
    public class GenerateMenuViewModel : Screen
    {
        public GenerateMenuViewModel(GeneratedMenuModel generatedMenu)
        {
            RecipesToShow = generatedMenu.WeekMenu;
        }
 
        
        private BindableCollection<KeyValuePair> _recipesToShow;

        public BindableCollection<KeyValuePair> RecipesToShow
        {
            get { return _recipesToShow; }

            set
            {
                if (_recipesToShow != value)
                {
                    _recipesToShow = value;
                    NotifyOfPropertyChange(() => RecipesToShow);
                }
            }
        }
   

    }
}
