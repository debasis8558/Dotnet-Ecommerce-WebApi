namespace Ecommerce_Backend.Exceptions
{
    public abstract class AppException : Exception
    {
        public AppException(string msg):base( msg){}
    }
}