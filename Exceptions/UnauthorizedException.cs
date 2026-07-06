namespace Ecommerce_Backend.Exceptions
{
    public class UnauthorizedException: AppException
    {
        public  UnauthorizedException(string msg):base(msg){}
    }
}