using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerOnboardingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBanks()
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Failed to retrieve banks");
            }

            var content = await response.Content.ReadAsStringAsync();

            // Return the raw JSON from Wema API
            return Content(content, "application/json");
        }
    }
}
