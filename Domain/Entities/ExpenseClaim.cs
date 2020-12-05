using Domain.Common;
using Newtonsoft.Json;
using System;

namespace Domain.Entities
{
    public class ExpenseClaim
    {
        private string _costCentre = Constants.ExpenseClaim.DefaultCostCentre;

        [JsonProperty("cost_centre")]
        public string CostCentre
        {
            get => _costCentre;
            set
            {
                _costCentre = String.IsNullOrEmpty(value) ? Constants.ExpenseClaim.DefaultCostCentre : value;
            }
        }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        private double _total;
        
        [JsonProperty("total")]
        public string Total
        {
            get => String.Format("{0:0.00}", _total);
            set
            {
                _total = Convert.ToDouble(value);
                _gst = Convert.ToDouble(value) * Constants.ExpenseClaim.Gst;
                _totalExcludingGst = _total - _gst;
            }
        }

        private double _gst;

        public string Gst 
        { 
            get => String.Format("{0:0.00}", _gst);
            set
            {
                _gst = Convert.ToDouble(value);
            }
        }


        private double _totalExcludingGst;

        public string TotalExcludingGst 
        { 
            get => String.Format("{0:0.00}", _totalExcludingGst);
            set
            {
                _totalExcludingGst = Convert.ToDouble(value);
            }
        }
    }
}
