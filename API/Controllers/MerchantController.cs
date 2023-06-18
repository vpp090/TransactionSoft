using Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Services.Model;

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
        public async Task<ActionResult<ServiceResponse<IReadOnlyList<Merchant>>>> GetAllMerchants()
        {
               var result = await _merchantService.GetMerchants();

               return result.Data != null ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IReadOnlyList<Merchant>>>> AddNewMerchants([FromForm] IFormFile csvFile)
        {
            var result = await _merchantService.CreateMerchants(csvFile);

            return  result.Data != null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteMerchant(int id)
        {
            var result = await _merchantService.DeleteMerchant(id);

            return result.Data ? Ok(result) : BadRequest(result);
        }
    }
}