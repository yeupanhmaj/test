using Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserViewModel
    {
        public System.Guid UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string RoldCode { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> LastEditedTime { get; set; }
        public Nullable<bool> Actived { get; set; }

        public string DrawerToLoad
        {
            get
            {
                switch (RoldCode)
                {
                    case ConstantRoldCode.BAOVE:
                        return "DrawerBaoVe";

                    case ConstantRoldCode.KIEMLIEU:
                        return "DrawerKiemLieu";

                    case ConstantRoldCode.TRUONGKIEMLIEU:
                        return "DrawerTruongKiemLieu";
                    default:
                        return "";
                }
            }
        }

        public string RoleName
        {
            get
            {
                switch (RoldCode)
                {
                    case ConstantRoldCode.BAOVE:
                        return "Bảo Vệ";

                    case ConstantRoldCode.KIEMLIEU:
                        return "Kiểm Liệu";

                    case ConstantRoldCode.TRUONGKIEMLIEU:
                        return "Trưởng Kiểm Liệu";
                    default:
                        return "";
                }
            }
        }
    }
}
