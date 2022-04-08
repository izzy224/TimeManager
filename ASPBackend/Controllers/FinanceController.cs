using ASPBackend.Controllers.Utility;
using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using ASPBackend.Models.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FinanceController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IWalletRepository _walletRepository;
        private IJwtService _jwtService;
        private ITransactionRepository _transactionRepository;
        private ITransactionCategoryRepository _transactionCategoryRepository;

        public FinanceController(IUserRepository userRepository, IWalletRepository walletRepository,
            IJwtService jwtService, ITransactionCategoryRepository transactionCategoryRepository, ITransactionRepository transactionRepository)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _jwtService = jwtService;
            _transactionCategoryRepository = transactionCategoryRepository;
            _transactionRepository = transactionRepository;
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetForLastDays([FromBody] FinanceGetDTO data)
        {
            var user = await _jwtService.GetUser(Request.Cookies["jwt"]);
            if(user != null)
            {
                var wallet = await _walletRepository.GetFirstAsync(user.UserId);
                return Ok(new { transactions = await _transactionRepository.GetByDate(data.GetDate(), data.LastDays, wallet.WalletId), walletId=wallet.WalletId});
            }
            return BadRequest();
        }
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _transactionCategoryRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransactionPostDTO postDTO)
        {
            try {
            var entity = new Transaction() { Amount = postDTO.Amount,
                Description = postDTO.Description,
                TransactionDate = postDTO.GetDate(),
                TransactionCategoryId = postDTO.TransactionCategoryId,
                WalletId = postDTO.WalletId ,
                Wallet = await _walletRepository.GetById(postDTO.WalletId),
                TransactionCategory = await _transactionCategoryRepository.GetById(postDTO.TransactionCategoryId)
            };
            await _transactionRepository.Insert(entity);
            return Ok(new { transactionId=entity.TransactionId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTransaction update)
        {
            var entity = await _transactionRepository.GetById(update.TransactionId);
            entity.Amount = update.Amount;
            entity.Description = update.Description;
            entity.TransactionCategoryId = update.TransactionCategoryId;
            entity.TransactionCategory = await _transactionCategoryRepository.GetById(update.TransactionCategoryId);
            await _transactionRepository.Save();
            return Ok(new { message = "success" });
            
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]int transactionId)
        {
            await _transactionRepository.Delete(transactionId);
            return Ok(new { message = "success" });
        }
        [HttpPost("getstats")]
        public async Task<IActionResult> GetStats([FromBody] FinanceGetDTO getDTO)
        {
            var user = await _jwtService.GetUser(Request.Cookies["jwt"]);
            if (user != null)
            {
                var wallet = await _walletRepository.GetFirstAsync(user.UserId);
                var stats = await _transactionRepository.GetStat(getDTO.GetDate(),getDTO.LastDays, wallet.WalletId);
                return Ok(stats);
            }
            return BadRequest();
        }
        [HttpPost("getmonthlystats")]
        public async Task<IActionResult> GetMonthlyStats([FromBody] DateObject date)
        {
            var user = await _jwtService.GetUser(Request.Cookies["jwt"]);
            if (user != null)
            {
                var wallet = await _walletRepository.GetFirstAsync(user.UserId);
                var monthlyStats = await _transactionRepository.GetMonthlyStat(date.GetDate(), wallet.WalletId);
                return Ok(monthlyStats);
            }
            return BadRequest();
        }
    }
}
