using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService tService)
        {
            _transactionService = tService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IReadOnlyList<Transaction>>>> GetAllTransactions()
        {
            var result = await _transactionService.GetAllTransactions();

            return result.Data != null ? Ok(result) : BadRequest(result);
        }

        [HttpPost("CreateTransaction")]
        public async Task<ActionResult<ServiceResponse<Transaction>>> CreateTransaction([FromBody]TransactionDto transaction)
        {
            var result = await _transactionService.CreateTransaction(transaction);

            return result.Data != null ? Ok(result) : BadRequest(result);    
        }

        [HttpPost("CreateTransactions")]
        public async Task<ActionResult<ServiceResponse<IReadOnlyList<Transaction>>>> CreateTransactions([FromBody]List<Transaction> transactions)
        {
            var result = await _transactionService.CreateTransactions(transactions);

            return result.Data != null ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetTransaction")]
        public async Task<ActionResult<ServiceResponse<IReadOnlyList<Transaction>>>> GetTransaction(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}