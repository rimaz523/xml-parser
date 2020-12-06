using Application.Reservations.Commands.CreateReservation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XmlParser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ReservationResponseDto>> Post(CreateReservationCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
