using Application.Common.Processors.Interfaces;
using Application.Common.Validators;
using Domain.Entities;
using FluentValidation;

namespace Application.ExpenseClaims.Commands.CreateExpenseClaim
{
    public class CreateExpenseClaimCommandValidator : AbstractValidator<CreateExpenseClaimCommand>
    {
        public CreateExpenseClaimCommandValidator
        (
            IXmlProcessor xmlProcessor    
        )
        {
            RuleFor(expenseClaimCommand => expenseClaimCommand.Message)
                .NotEmpty()
                .MaximumLength(1000)
                .IsWellFormedXml(xmlProcessor)
                .HasXmlTag(xmlProcessor, "total")
                .IsValidNumber(xmlProcessor, "total");
        }
    }
}
