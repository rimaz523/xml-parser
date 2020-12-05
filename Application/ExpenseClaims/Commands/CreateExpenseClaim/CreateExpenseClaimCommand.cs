using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ExpenseClaims.Commands.CreateExpenseClaim
{
    public class CreateExpenseClaimCommand : IRequest<ExpenseClaimResponseDto>
    {
        public string Message { get; set; }
    }

    public class CreateExpenseClaimCommandHandler : IRequestHandler<CreateExpenseClaimCommand, ExpenseClaimResponseDto>
    {
        public async Task<ExpenseClaimResponseDto> Handle(CreateExpenseClaimCommand request, CancellationToken cancellationToken)
        {
            return new ExpenseClaimResponseDto
            {
                Message = "works in Mediatr!"
            };
        }
    }
}
