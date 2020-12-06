using Application.Common.Processors.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<ReservationResponseDto>
    {
        public string Message { get; set; }
    }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ReservationResponseDto>
    {
        private readonly IXmlProcessor _xmlProcessor;
        private readonly IMapper _mapper;
        public CreateReservationCommandHandler
        (
            IXmlProcessor xmlProcessor,
            IMapper mapper
        )
        {
            _xmlProcessor = xmlProcessor;
            _mapper = mapper;
        }

        public async Task<ReservationResponseDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation();
            PropertyInfo[] properties = typeof(Reservation).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.CustomAttributes.Count() > 0)
                {
                    var xmlTag = property.CustomAttributes.First().ConstructorArguments.First().Value.ToString();
                    property.SetValue(reservation, _xmlProcessor.GetTagContent(xmlTag, request.Message));
                }
            }
            return _mapper.Map<ReservationResponseDto>(reservation);
        }
    }
}
