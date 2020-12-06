using Application.Common.Processors.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Reflection;
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
        private readonly IXmlProcessor _xmlProcessor;
        private readonly IMapper _mapper;
        public CreateExpenseClaimCommandHandler
        (
            IXmlProcessor xmlProcessor,
            IMapper mapper
        )
        {
            _xmlProcessor = xmlProcessor;
            _mapper = mapper;
        }

        public async Task<ExpenseClaimResponseDto> Handle(CreateExpenseClaimCommand request, CancellationToken cancellationToken)
        {
            var expenseClaim = new ExpenseClaim();
            PropertyInfo[] properties = typeof(ExpenseClaim).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.CustomAttributes.Count() > 0)
                {
                    var xmlTag = property.CustomAttributes.First().ConstructorArguments.First().Value.ToString();
                    property.SetValue(expenseClaim, _xmlProcessor.GetTagContent(xmlTag, request.Message));
                }
            }
            return _mapper.Map<ExpenseClaimResponseDto>(expenseClaim);
        }
    }
}
