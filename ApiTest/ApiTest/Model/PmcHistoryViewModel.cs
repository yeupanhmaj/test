using System;

namespace ViewModels
{
    public class PmcHistoryViewModel
    {
        public int ID   { get; set; }
        public string BUKRS { get; set; }
        public string ZKEY { get; set; }
        public string NAME_FM { get; set; }
        public DateTime TIME_SEND { get; set; }
        public DateTime TIME_RECEIVE { get; set; }
        public string STATUS{ get; set; }
        public string TYPE { get; set; }
        public string GHI_CHU { get; set; }
    }
}
