using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ScaleTicketMobileHistoryViewModel
    {
        public string HistoryType { get; set; }
        public DateTime CreateDate { get; set; }
        public string FullName { get; set; }
        public string HistoryNote
        {
            get
            {
                switch (HistoryType)
                {
                    case "CREATE":
                        return string.Format("{0} đã thêm lúc {1}", FullName, CreateDate.ToString("HH:mm dd/MM/yyyy"));
                    case "EDIT":
                        return string.Format("{0} đã cập nhật lúc {1}", FullName, CreateDate.ToString("HH:mm dd/MM/yyyy"));
                    case "VERIFY":
                        return string.Format("{0} đã duyệt lúc {1}", FullName, CreateDate.ToString("HH:mm dd/MM/yyyy"));
                    default:
                        return "";
                }
            }
        }
    }
}
