using System;

namespace ViewModels
{
    public class DataScaleTicketPOViewModel
    {
        public string PONumber { get; set; }
        public string POLine { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal POQty { get; set; }
        public string UNIT { get; set; }
        public decimal SoLuongDaNhap { get; set; }
        public int TyLeTrongLuong { get; set; }
        public decimal Qty1 { get; set; }
        public string Unit1 { get; set; }
        public decimal TapChat { get; set; }
        public decimal Qty2 { get; set; }
        public string Unit2 { get; set; }
        public bool chkChon { get; set; }
        public Guid? ScaleTicketPODetailId { get; set; }
    }
}