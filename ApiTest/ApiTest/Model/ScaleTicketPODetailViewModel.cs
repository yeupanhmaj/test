using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ScaleTicketPODetailViewModel
    {
        public System.Guid ScaleTicketPODetailId { get; set; }
        public Nullable<System.Guid> ScaleTicketId { get; set; }
        public string PONumber { get; set; }
        public string POLine { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> POQty { get; set; }
        public string UNIT { get; set; }
        public Nullable<decimal> SoLuongDaNhap { get; set; }
        public Nullable<decimal> TyLeTrongLuong { get; set; }
        public Nullable<decimal> Qty1 { get; set; }
        public Nullable<decimal> TapChat { get; set; }
        public string Unit1 { get; set; }
        public Nullable<decimal> Qty2 { get; set; }
        public string Unit2 { get; set; }
        public Nullable<bool> isNoPO { get; set; }
        public Nullable<bool> isSendToSAPCompleted { get; set; }
    }
}
