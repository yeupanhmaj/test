using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class VehicleRegisterMobileDTO
    {
        public System.Guid VehicleRegisterMobileId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> RegisterTime { get; set; }
        public string DVVC { get; set; }
        public string SoDonHang { get; set; }
        public string GiaoNhan { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverIdCard { get; set; }
        public string Note3 { get; set; }
    }
}
