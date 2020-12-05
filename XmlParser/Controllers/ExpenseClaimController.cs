using Application.ExpenseClaims.Commands.CreateExpenseClaim;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XmlParser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseClaimController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ExpenseClaimResponseDto>> Post(CreateExpenseClaimCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
