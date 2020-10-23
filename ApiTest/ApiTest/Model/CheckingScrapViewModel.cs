using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CheckingScrapViewModel
    {
        public System.Guid CheckingScrapId { get; set; }
        public int ChekingScrapIdInt { get; set; }
        public Nullable<System.Guid> ScaleTicketId { get; set; }
        public Nullable<System.Guid> ScaleTicketMobileId { get; set; }
        public string RFID { get; set; }
        public Nullable<System.DateTime> InHourGuard { get; set; }
        public Nullable<System.DateTime> OutHourGuard { get; set; }
        public string GiaoNhan { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverIdCard { get; set; }
        public bool IsVehicleNew { get; set; }
        public string InGateId { get; set; }
        public string OutGateId { get; set; }
        public string ReceiveType { get; set; }
        public Nullable<System.Guid> User1Id { get; set; }
        public string Note1 { get; set; }
        public Nullable<System.Guid> User2Id { get; set; }
        public Nullable<System.Guid> User3Id { get; set; }
        public string Note3 { get; set; }
        public Nullable<System.DateTime> CheckingTime { get; set; }
        public Nullable<System.Guid> User4Id { get; set; }
        public Nullable<System.DateTime> VerifyTime { get; set; }
        public Nullable<System.Guid> User5Id { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<bool> Actived { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public Nullable<int> Step { get; set; }
        //Edit 23/06/2020
        public Nullable<int> POMasterRegisterId { get; set; }
        public Nullable<int> SOMasterRegisterId { get; set; }
        public Nullable<bool> IsLockCard { get; set; }
        public Nullable<System.DateTime> StartCheckingTime { get; set; }
    }
}
