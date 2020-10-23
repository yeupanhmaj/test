using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class VehiclePhanBoViewModel
    {
        public string VehicleNumber { get; set; }
        public decimal VehicleWeight { get; set; }
        public decimal TrongLuongDangKiem { get; set; }
        public decimal TyLeVuot { get; set; }
        public decimal TLToiDa { get; set; }
        //số này nè
        public decimal TLHangChoDuoc { get; set; }
        public decimal TypeDisplay { get; set; }

        //Trọng lượng hàng phân bổ
        public decimal TLHangPhanBo { get; set; }
        public decimal TapChatPhanBo { get; set; }
        //Phần trăm của 1 xe/ tổng các xe phân bổ
        //VD: xe đó 35 Tấn
        //Tổng 3 xe: 35 + 35 + 40
        // => xe này 35%
        public int PhanTram { get; set; }


        //Dành cho phần tách SO Detail
        public decimal? Qty2 { get; set; }

        //Tách container
        public bool isDoiXe { get; set; }
        public int SoLuongContainer { get; set; }
        public string SoHieuContainer1 { get; set; }
        public string SoHieuContainer2 { get; set; }


    }
}
