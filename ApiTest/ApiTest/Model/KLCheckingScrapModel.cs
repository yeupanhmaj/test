using ApiTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Model
{
    public class KLCheckingScrapModel
    {
        public ScaleTicketViewModel ScaleTicket { get; set; }
        public List<ScaleTicketPODetailViewModel> ScaleTicketPODetailList { get; set; }
        public CheckingScrapViewModel checkingScrap { get; set; }
        public VehicleViewModel VehicleModel { get; set; }
        public List<ProductModel> ProductList { get; set; }
        public bool IsEdit { get; set; }
        public List<ScaleTicketMobileHistoryViewModel> History { get; set; }
        public bool IsDaDuyet { get; set; }
    }
}
