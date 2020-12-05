using FluentValidation;

namespace Application.ExpenseClaims.Commands.CreateExpenseClaim
{
    public class CreateExpenseClaimCommandValidator : AbstractValidator<CreateExpenseClaimCommand>
    {
        public CreateExpenseClaimCommandValidator()
        {
            RuleFor(expenseClaimCommand => expenseClaimCommand.Message).NotEmpty().MaximumLength(500);
        }
    }
}
