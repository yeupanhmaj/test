using System;

namespace ViewModels
{
    public class PolineViewModel
    {
        public string POLine { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? Qty { get; set; }
        public string UNIT { get; set; }
        public decimal? OverTolerance { get; set; }
        public decimal? UnderTolerance { get; set; }
        public string isUnlimited { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string isDeliveryCompleted { get; set; }
        public string SoLuongDaNhap { get; set; }
    }
}