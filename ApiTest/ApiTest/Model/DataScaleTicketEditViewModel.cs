using System;

namespace ViewModels
{
    public class DataScaleTicketEditViewModel
    {
        public Guid ScaleTicketId { get; set; }
        public string ScaleTicketTypeCode { get; set; }
        public string ScaleTicketCode { get; set; }
        public string VehicleNumber { get; set; }
        public DateTime? InHour { get; set; }
        public DateTime? OutHour { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string WarehouseEntry { get; set; }
        public string WarehouseExport { get; set; }
        public bool IsCheck { get; set; }
        public bool IsApprove { get; set; }
        public decimal? ActualWeightAfterReduction { get; set; }
        public decimal? Qty1 { get; set; }
        public string PONumber { get; set; }
    }
}