using CustomerOnboardingApi.DTOs;
using CustomerOnboardingApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerOnboardingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("onboard")]
public async Task<IActionResult> Onboard([FromBody] CustomerOnboardRequest request)
        {
            var result = await _customerService.OnboardCustomerAsync(request);
            return Ok(new { message = result });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpVerificationRequest request)
        {
            var result = await _customerService.VerifyOtpAsync(request);
            return Ok(new { message = result });
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }
    }
}
