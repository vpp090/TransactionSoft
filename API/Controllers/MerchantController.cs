using Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantController : ControllerBase
    {
        private IMerchantService _merchantService;
        private ILogger _logger;

        public MerchantController(IMerchantService mService, ILogger logger)
        {
            _merchantService = mService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Merchant>>> GetAllMerchants()
        {
            try
            {
                 var merchants = await _merchantService.GetMerchants();

                 return Ok(merchants);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
                return BadRequest();
            }
           
        }

        [HttpPost]
        public async Task<ActionResult<IReadOnlyList<Merchant>>> AddNewMerchants([FromForm] IFormFile csvFile)
        {
            var result = await _merchantService.CreateMerchants(csvFile);

            return Ok(result);
        }
    }
}