using Application.Common.Processors.Interfaces;
using Application.Common.Validators;
using FluentValidation;

namespace Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator
        (
            IXmlProcessor xmlProcessor
        )
        {
            RuleFor(expenseClaimCommand => expenseClaimCommand.Message)
                .NotEmpty()
                .MaximumLength(1000)
                .IsWellFormedXml(xmlProcessor);
        }
    }
}
