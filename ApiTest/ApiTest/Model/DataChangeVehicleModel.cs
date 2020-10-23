using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DataChangeVehicleModel
    {
        public Guid VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public decimal VehicleWeight { get; set; }
        public decimal TrongLuongDangKiem { get; set; }
        public decimal TyLeVuot { get; set; }
        public decimal TLToiDa { get; set; }
        public decimal TLHangChoDuoc { get; set; }
    }
}
