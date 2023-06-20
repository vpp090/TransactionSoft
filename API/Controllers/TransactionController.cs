using Core.DTOs;
using Core.Entities;
using Hangfire;
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
        private readonly IRecurringJobManager _recurringJobManager;
        public TransactionController(ITransactionService tService, IRecurringJobManager recurringJobManager)
        {
            _transactionService = tService;
            _recurringJobManager = recurringJobManager;
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
        public async Task<ActionResult<ServiceResponse<IReadOnlyList<Transaction>>>> CreateTransactions([FromBody]List<TransactionDto> transactions)
        {
            var result = await _transactionService.CreateTransactions(transactions);

            return result.Data != null ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetTransaction")]
        public async Task<ActionResult<ServiceResponse<IReadOnlyList<Transaction>>>> GetTransaction(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("ProcessTransaction")]
        public async Task<ActionResult<ServiceResponse<Transaction>>> ProcessTransaction(Guid transId)
        {
           var result = await _transactionService.ProcessTransaction(transId);

           return result.Error == null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTransaction(Guid id)
        {
            throw new NotImplementedException();

         }

        [HttpDelete("ScheduledDelete")]
        public IActionResult DeleteTransactionsRecurringly()
        {
            _recurringJobManager.AddOrUpdate("jobId", () => _transactionService.DeleteTransactionsRecurringly(), Cron.Hourly);
            return Ok();   
        }
    }
}