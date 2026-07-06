namespace Ecommerce_Backend.Exceptions
{
    public class NotFoundException(string msg) : AppException(msg)
    {
    }
}