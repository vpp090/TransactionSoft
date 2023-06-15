
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantController : ControllerBase
    {
        [HttpGet]
        public Task<ActionResult> GetAllMerchants()
        {
            return null;
        }

        [HttpPost]
        public Task<ActionResult> AddNewMerchants()
        {
            return null;
        }
    }
}