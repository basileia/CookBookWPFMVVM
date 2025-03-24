using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CookBookWPFMVVM.ViewModels
{
    public class BaseViewModel : Screen, INotifyDataErrorInfo
    {
        protected readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Any();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
                return null;

            return _errors[propertyName];
        }

        protected void SetError(string propertyName, string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _errors[propertyName] = new List<string> { errorMessage };
            }
            else
            {
                _errors.Remove(propertyName);
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ValidateProperty<T>(string propertyName, T value, Func<T, string> validationMethod)
        {
            SetError(propertyName, validationMethod(value));
        }

        protected void ValidatePropertyWithList<T, U>(string propertyName, T value, U list, Func<T, U, string> validationMethod)
        {
            SetError(propertyName, validationMethod(value, list));
        }
    }
}
