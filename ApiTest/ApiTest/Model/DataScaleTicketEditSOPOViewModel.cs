using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DataScaleTicketEditSOPOViewModel
    {
        public Guid ScaleTicketId { get; set; }
        public int SyncPOId { get; set; }
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
        
    }
}
