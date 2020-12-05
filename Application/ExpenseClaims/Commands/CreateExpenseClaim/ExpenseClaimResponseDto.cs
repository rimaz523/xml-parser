using Application.Common.Mappings;
using Domain.Entities;

namespace Application.ExpenseClaims.Commands.CreateExpenseClaim
{
    public class ExpenseClaimResponseDto : IMapFrom<ExpenseClaim>
    {
        public string CostCentre { get; set; }

        public string PaymentMethod { get; set; }

        public string Total { get; set; }

        public string Gst { get; set; }

        public string TotalExcludingGst { get; set; }
    }
}
