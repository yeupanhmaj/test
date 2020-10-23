
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CustomerViewModel 
    {
        public System.Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public Nullable<bool> isSAPData { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> LastEditedTime { get; set; }
        public Nullable<bool> Actived { get; set; }
        public Nullable<int> CungDuongCode { get; set; }
        public string CungDuongName { get; set; }
    }
}
