using System;

namespace ViewModels
{
    public class VehicleRegistersViewModel
    {
        public VehicleRegistersViewModel()
        {
            SOMasterRegisterId = Guid.Empty;
            POMasterRegisterId = Guid.Empty;
        }
        public string VehicleNumber { get; set; }
        public int DeliveryType { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderDateStr { get { return OrderDate.ToString("dd/MM/yyyy"); } }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryDateStr { get { return DeliveryDate.ToString("dd/MM/yyyy"); } }
        public string DeliveryTimeStr { get { return DeliveryDate.ToString("HH:mm"); } }
        public Guid SOMasterRegisterId { get; set; }
        public Guid POMasterRegisterId { get; set; }

    }
}
