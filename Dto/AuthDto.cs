namespace Ecommerce_Backend.Dto
{
    public class SignUpDto
    {
        public string? Name {  get; set; }
        public string? Email {  get; set; }
        public string? Role {get;set;}="Customer";
        public string? Password { get; set; }
    }
    public class LoginDto
    {
          public string? Email {  get; set; }
          public string? Password { get; set; }
    }
}
