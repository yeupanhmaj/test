using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DataScaleTicketSODetailViewModel
    {
        public string SONumber { get; set; }

        public string SOLine { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public decimal? SOQty { get; set; }

        //public string UNIT { get; set; }

        public decimal? SoLuongDaXuat{ get; set; }

        public decimal? Qty1 { get; set; }

        //public string Unit1 { get; set; }

        public decimal? Qty2 { get; set; }

        public string Unit2 { get; set; }

        public decimal? MinSingleWeight { get; set; }

        public decimal? MaxSingleWeight { get; set; }

        public decimal? ActualSingleWeight { get; set; }
        public bool chkChon { get; set; }
        public string CustomerCode { get; set; }
    }
}
