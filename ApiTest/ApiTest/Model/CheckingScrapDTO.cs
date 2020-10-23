
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CheckingScrapDTO
    {
        public string RFID { get; set; }
        public ScaleTicketViewModel ScaleTicket { get; set; }
        public List<ScaleTicketPODetailViewModel> ScaleTicketPODetailList { get; set; }
        public List<ScaleTicketPODetailViewModel> PhanBoData { get; set; }

        public string VehicleCode { get; set; }
        public string NumberCong { get; set; }
        public string container1Code { get; set; }
        public string container2Code { get; set; }
        public bool Is20Feet { get; set; }
        public int TruKg { get; set; }
        public int TruPhanTram { get; set; }
        public string Note { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDuyetPKL { get; set; }
    }
}
