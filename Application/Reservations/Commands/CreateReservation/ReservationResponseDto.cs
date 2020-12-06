using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Reservations.Commands.CreateReservation
{
    public class ReservationResponseDto : IMapFrom<Reservation>
    {
        public string Vendor { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }
    }
}
