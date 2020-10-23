using Constant.Enums;
using System;

namespace ViewModels
{
    public class VehicleRegisterDetailViewModel
    {
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public string IdNumber { get; set; }
        public int DeliveryType { get; set; }
        public string DeliveryTypeDisplay { get { return (((DeliveryTypeEnum)DeliveryType)).GetDisplayName(); } }
        public string Note { get; set; }
        public string SONumber { get; set; }
        public string PONumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderDateStr { get { return OrderDate.ToString("dd/MM/yyyy"); } }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryDateStr { get { return DeliveryDate.ToString("dd/MM/yyyy"); } }
        public string DeliveryTimeStr { get { return DeliveryDate.ToString("HH:mm"); } }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public Guid POMasterRegisterId { get; set; }
        public Guid SOMasterRegisterId { get; set; }
        public string VehicleOwner { get; set; }
        public string VehicleOwnerName { get; set; }

    }
}
