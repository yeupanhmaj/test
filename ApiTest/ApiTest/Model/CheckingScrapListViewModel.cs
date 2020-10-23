using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CheckingScrapListViewModel
    {
        public string VehicleNumber { get; set; }
        public string RFID { get; set; }
        public bool? IsLockCard { get; set; }
        public string Status { get; set; }
        public string Status2 { get; set; }
        public string Status3 { get; set; }
        public string Status4 { get; set; }
        public string Status5 { get; set; }
        public string Status6 { get; set; }
        public string Status7 { get; set; }
        public string Status8 { get; set; }
        public int? Step { get; set; }
    }
}
