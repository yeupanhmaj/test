using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ScaleTicketViewModel
    {
        public Guid ScaleTicketId { get; set; }
        public string ScaleTicketCode { get; set; }
        public string ScaleTicketTypeCode { get; set; }
        public string VehicleTypeCode { get; set; }
        public string VehicleNumber { get; set; }
        public string BargeNumber { get; set; }
        public string ContainerCount { get; set; }
        public string TrailersNumber { get; set; }
        public Nullable<System.DateTime> InHour { get; set; }
        public Nullable<System.DateTime> OutHour { get; set; }
        public Nullable<decimal> FirstWeight { get; set; }
        public Nullable<decimal> SecondWeight { get; set; }
        public Nullable<decimal> ActualWeight { get; set; }
        public Nullable<decimal> PercentReduced { get; set; }
        public Nullable<decimal> KgReduced { get; set; }
        public Nullable<decimal> ActualWeightAfterReduction { get; set; }
        public Nullable<decimal> TotalReduced { get; set; }
        public string Description { get; set; }
        public Nullable<bool> isTest { get; set; }
        public string SoftCode { get; set; }
        public Nullable<System.Guid> FirstUserId { get; set; }
        public Nullable<System.Guid> SecondUserId { get; set; }
        public Nullable<bool> isSendToSAPCompleted { get; set; }
        public Nullable<bool> isInvalidSAP { get; set; }
        public string InvalidSAPMessage { get; set; }
        public Nullable<bool> isXeNoiBo { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public Nullable<bool> isQuaTai { get; set; }
        public Nullable<bool> StatusIP { get; set; }
        public Nullable<bool> isDonTrongMin { get; set; }
        public Nullable<bool> isDonTrongMax { get; set; }
        public Nullable<bool> isVuotTyLeOD { get; set; }
        public Nullable<int> CungDuongCode { get; set; }
        public string CungDuongName { get; set; }
        public string VehicleOwner { get; set; }
        public string VehicleOwnerName { get; set; }
        public Nullable<bool> is20Feet { get; set; }
        public Nullable<bool> is40Feet { get; set; }
        public string SoHieuCont1 { get; set; }
        public string SoHieuCont2 { get; set; }

    }
}
