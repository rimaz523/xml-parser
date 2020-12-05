using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace XmlParser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseClaimController : ControllerBase
    {
        private readonly ILogger<ExpenseClaimController> _logger;

        public ExpenseClaimController(ILogger<ExpenseClaimController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<string> Post()
        {
            return "works!";
        }
    }
}
