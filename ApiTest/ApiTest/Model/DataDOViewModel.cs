using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DataDOViewModel
    {
        public bool chkChon { get; set; }
        public string DONumber { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> SoCuonBo { get; set; }
        public string CompanyCode { get; set; }
    }
}
