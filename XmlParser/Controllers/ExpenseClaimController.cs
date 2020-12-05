using Application.ExpenseClaims.Commands.CreateExpenseClaim;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace XmlParser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseClaimController : ApiControllerBase
    {
        private readonly ILogger<ExpenseClaimController> _logger;

        public ExpenseClaimController(ILogger<ExpenseClaimController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseClaimResponseDto>> Post(CreateExpenseClaimCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
