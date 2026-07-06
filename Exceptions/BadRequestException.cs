namespace Ecommerce_Backend.Exceptions
{
    public class BadRequestException : AppException
    {
        public  BadRequestException(string msg):base(msg){}
    }
}