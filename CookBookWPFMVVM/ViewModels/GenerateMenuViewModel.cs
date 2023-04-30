using Caliburn.Micro;
using CookBookWPFMVVM.Models;

namespace CookBookWPFMVVM.ViewModels
{
    public class GenerateMenuViewModel : Screen
    {
        CookBookModel cookBook = new CookBookModel();

        public GenerateMenuViewModel(CookBookModel cookbook, GeneratedMenuModel generatedMenu)
        {
            cookBook = cookbook;
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
