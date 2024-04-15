namespace WineCraze.Core.Exceptions
{
    public class WineNotFoundException : Exception
    {
        public WineNotFoundException(string message) : base(message)
        {
        }

        public WineNotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}