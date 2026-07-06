namespace Ecommerce_Backend.Exceptions
{
    public class ForbiddenException: AppException
    {
        public  ForbiddenException(string msg):base(msg){}
    }
}