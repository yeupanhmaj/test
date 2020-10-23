using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Model
{
    public class ScaleTicketMobileModel
    {
        public Guid ScaleTicketMobileId { get; set; }
        public Guid? ScaleTicketId { get; set; }
        public string ScaleTicketCode { get; set; }
        public string VehicleTypeCode { get; set; }
        public string VehicleNumber { get; set; }
        public string ContainerCount { get; set; }
        public bool? is20Feet { get; set; }
        public bool? is40Feet { get; set; }
        public string SoHieuCont1 { get; set; }
        public string SoHieuCont2 { get; set; }
        public string TrailersNumber { get; set; }
        public decimal? PercentReduced { get; set; }
        public decimal? KgReduced { get; set; }
        public string Description { get; set; }
        public bool? isXeNoiBo { get; set; }
    }
}
