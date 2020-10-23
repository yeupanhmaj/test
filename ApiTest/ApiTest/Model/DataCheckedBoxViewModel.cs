using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DataCheckedBoxViewModel
    {
        public bool isSAPData { get; set; }
        public Guid guid { get; set; }
        public string Code { get; set; }
        public int Id { get; set; }
    }
}
