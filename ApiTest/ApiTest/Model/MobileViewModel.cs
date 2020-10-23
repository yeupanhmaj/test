using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class GateViewModel
    {
        public string GateId { get; set; }
        public string GateName { get; set; }
    }

    public class VehicleViewModel
    {
        public Guid VehicleId { get; set; }
        public int Type { get; set; }
        public string TypeText
        {
            get
            {
                switch (Type)
                {
                    case 1:
                        return "Nội bộ";
                    case 2:
                        return "Khách hàng";
                    case 3:
                        return "DVVC";

                    default:
                        return "Xe mới";
                }
            }
        }
        public string VehicleNumber { get; set; }
        public string VehicleOwner { get; set; }
    }

    public class SaveVehicleViewModel
    {
        //public SaveVehicleViewModel()
        //{
        //    POMasterRegisterId = Guid.Empty;
        //    SOMasterRegisterId = Guid.Empty;
        //}
        public string RFID { get; set; }
        public string TenTaiXe { get; set; }
        public string BienSoXe { get; set; }
        public string CMND { get; set; }
        public string SelectedGate { get; set; }
        public string GiaoNhan { get; set; }
        public string Note { get; set; }
        public int DeliveryType { get; set; }
        //Edit 23/06/2020
        //public Guid POMasterRegisterId { get; set; }
        //public Guid SOMasterRegisterId { get; set; }

    }

}
