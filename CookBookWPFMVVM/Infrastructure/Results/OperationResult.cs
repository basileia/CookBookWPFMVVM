namespace CookBookWPFMVVM.Infrastructure.Results
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string ErrorMessage { get; }

        private OperationResult(T value)
        {
            IsSuccess = true;
            Value = value;
        }

        private OperationResult(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }

        public static OperationResult<T> Success(T value) => new OperationResult<T>(value);
        public static OperationResult<T> Failure(string errorMessage) => new OperationResult<T>(errorMessage);
    }
}
