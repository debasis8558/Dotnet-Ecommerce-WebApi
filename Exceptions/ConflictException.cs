namespace Ecommerce_Backend.Exceptions
{
    public class ConflictException: AppException
    {
        public  ConflictException(string msg):base(msg){}
    }
}