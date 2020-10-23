using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public partial class UpdateLogViewModel
    {
        public System.Guid UpdateId { get; set; }
        public string ID { get; set; }
        public string CompanyCode { get; set; }
        public string ZKEY { get; set; }
        public string FunctionName { get; set; }
        public string TimeSend { get; set; }
        public string TimeReceive { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
    }
}
