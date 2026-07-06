using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Ecommerce_Backend.Controllers
{   [ApiController]
[Route("api/payments")]
    public class PaymentController(IPaymentService service) : ControllerBase
    {   [HttpPost]
    [Authorize]
        public async Task<IActionResult> MakePayment(PaymentReqDto dto)
        {   
            var res=await service.Payment(dto);
            System.Console.WriteLine(res.Status);
            return Ok(new{msg="req implemented successfully",data=res});
        }
    }
}