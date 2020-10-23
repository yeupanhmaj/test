using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Common;
using ApiTest.Model;
using ApiTest.Service;
using Constant;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingScrapController : ControllerBase
    {
        // GET: api/<CheckingScrapController>
        [HttpGet]
        public ListResponeMessage<CheckingScrapViewModel> GetCheckingScrap([FromHeader] string key, [FromHeader] string token, string rfid, bool isDone)
        {
            if (Encrypt.checkToken(token, key))
            {
                ListResponeMessage<CheckingScrapViewModel> ret = new ListResponeMessage<CheckingScrapViewModel>();
                try
                {
                    ret.isSuccess = true;
                    ret.data = CheckingScrapService.GetInstance().GetCheckingScrap(rfid, isDone);
                }
                catch (Exception ex)
                {
                    ret.isSuccess = false;
                    ret.err.msgCode = "005";
                    ret.err.msgString = ex.ToString();
                }
                return ret;
            }
            else
            {
                ListResponeMessage<CheckingScrapViewModel> ret = new ListResponeMessage<CheckingScrapViewModel>();
                ret.isSuccess = false;
                ret.err.msgCode = "Internal Error !!!";
                ret.err.msgString = "Key hoặc token không chính xác";
                return ret;
            }
        }
        // GET api/kiemlieu
        [HttpGet("kiemlieu/{rfid}")]
        public SingleResponeMessage<KLCheckingScrapModel> GetCheckingScrapKL([FromHeader] string key, [FromHeader] string token,string rfid = "")
        {
            SingleResponeMessage<KLCheckingScrapModel> ret = new SingleResponeMessage<KLCheckingScrapModel>();
            if (Encrypt.checkToken(token, key))
            {
                if (string.IsNullOrEmpty(rfid))
                {
                    ret.isSuccess = false;
                    ret.err.msgCode = "Internal Error !!!";
                    ret.err.msgString = "Không đọc được thẻ, vui lòng thử lại";
                    return ret;
                }
                var checkingScrap = CheckingScrapService.GetInstance().GetCheckingScrap(rfid, false).FirstOrDefault();
                if (checkingScrap == null)
                {
                    ret.isSuccess = false;
                    ret.err.msgCode = "Internal Error !!!";
                    ret.err.msgString = "Không tìm thấy thông tin thẻ từ";
                    return ret;
                }
                // TODO: Check nếu đã có thông tin ScaleTicketMobile thì lấy ra và sửa
                var ScaleTicket = ScaleTicketService.GetInstance().GetScaleTicket(checkingScrap.ScaleTicketId).FirstOrDefault(); 
                
                if (ScaleTicket == null)
                {
                    ret.isSuccess = false;
                    ret.err.msgCode = "Internal Error !!!";
                    ret.err.msgString = "Không tìm thấy phiếu cân, có thể nhân viên bàn cân quên quét thẻ từ, vui lòng kiểm tra lại!";
                    return ret;
                }
                var ScaleTicketPODetailList = ScaleTicketPODetailService.GetInstance().GetListScaleTicketPODetail(ScaleTicket.ScaleTicketId);

                Guid tempId = ScaleTicket.ScaleTicketId;

                var IsEdit = false;

                var History = new List<ScaleTicketMobileHistoryViewModel>();

                if (checkingScrap.ScaleTicketMobileId != null && !checkingScrap.ScaleTicketMobileId.Equals(Guid.Empty))
                {

                    ScaleTicket = ScaleTicketMobileModelService.GetInstance().pGetScaleTicketMobile(checkingScrap.ScaleTicketMobileId).FirstOrDefault();

                    //ScaleTicket.ScaleTicketId = tempId;

                    ScaleTicketPODetailList = ScaleTicketPODetailMobileModelService.GetInstance().pGetListScaleTicketPOMobileDetail(checkingScrap.ScaleTicketMobileId);

                    IsEdit = true;
                   
                    History = ScaleTicketMobileHistoryService.GetInstance().GetScaleTicketMobileHistory(checkingScrap.ScaleTicketId);

                }

                var ProductList = ProductService.GetInstance().GetListProduct(true);

                var VehicleModel = VehicleService.GetInstance().GetVehicleInfo(checkingScrap.VehicleNumber);

                var IsDaDuyet = false;

                if (checkingScrap.VerifyTime != null && checkingScrap.VerifyTime != DateTime.MinValue)
                {
                    IsDaDuyet = true;
                }
                KLCheckingScrapModel kLCheckingScrap = new KLCheckingScrapModel
                {
                    ScaleTicket = ScaleTicket,
                    ScaleTicketPODetailList=ScaleTicketPODetailList,
                    checkingScrap=checkingScrap,
                    VehicleModel=VehicleModel,
                    ProductList=ProductList,
                    IsEdit=IsEdit,
                    History=History,
                    IsDaDuyet=IsDaDuyet
                };

                ret.isSuccess = true;
                ret.item = kLCheckingScrap;
                ret.err.msgCode = "Internal Error !!!";
                ret.err.msgString = "Lấy dữ liệu thành công!";   
                
                return ret;
            }
            else
            {               
                ret.isSuccess = false;
                ret.err.msgCode = "Internal Error !!!";
                ret.err.msgString = "Key hoặc token không chính xác";
                return ret;
            }            
        }
        // GET api/CheckingScrap/{rfid}
        [HttpGet("{rfid}")]
        public SingleResponeMessage<CheckingScrapViewModel> Get([FromHeader] string key, [FromHeader] string token, string rfid)
        {
            if (Encrypt.checkToken(token, key))
            {
                SingleResponeMessage<CheckingScrapViewModel> ret = new SingleResponeMessage<CheckingScrapViewModel>();
                try
                {
                    ret.isSuccess = true;
                    ret.item = CheckingScrapService.GetInstance().GetCheckingScrap(rfid, false).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    ret.isSuccess = false;
                    ret.err.msgCode = "005";
                    ret.err.msgString = ex.ToString();
                }
                return ret;
            }
            else
            {
                SingleResponeMessage<CheckingScrapViewModel> ret = new SingleResponeMessage<CheckingScrapViewModel>();
                ret.isSuccess = false;
                ret.err.msgCode = "Internal Error !!!";
                ret.err.msgString = "Key hoặc token không chính xác";
                return ret;
            }
        }

        // POST api/<CheckingScrapController>
        [HttpPost]
        public ActionMessage SaveCheckingScrapIn([FromHeader] string key, [FromHeader] string token, [FromBody] SaveVehicleViewModel input, Guid userID)
        {
            if (Encrypt.checkToken(token, key))
            {
                ActionMessage ret = new ActionMessage();

                var item = CheckingScrapService.GetInstance().GetCheckingScrap(input.RFID, false);
                if (item.Count > 0)
                {
                    ret.isSuccess = false;
                    ret.err.msgCode = "Internal Error !!!";
                    ret.err.msgString = string.Format("Thẻ này đang được sử dụng cho xe: \"{0}\"!", item.FirstOrDefault().VehicleNumber);
                }
                else
                {
                    var checkingModel = new CheckingScrapViewModel();
                    checkingModel.CheckingScrapId = Guid.NewGuid();
                    checkingModel.User1Id = userID;
                    checkingModel.InHourGuard = DateTime.Now;
                    checkingModel.RFID = input.RFID.Replace("http://", "");
                    checkingModel.VehicleNumber = input.BienSoXe;

                    checkingModel.DriverName = input.TenTaiXe;
                    checkingModel.DriverIdCard = input.CMND;
                    checkingModel.GiaoNhan = input.GiaoNhan;
                    checkingModel.InGateId = input.SelectedGate;
                    checkingModel.Note1 = input.Note;
                    checkingModel.Step = ConstantStepKL._1VAOCONG;
                    checkingModel.IsDone = false;

                    int result = CheckingScrapService.GetInstance().InsertCheckingScrap(checkingModel);
                    return ((result == 1) ?
                    new ActionMessage {
                        isSuccess = false,
                        err = new ErorrMssage
                        {
                            msgCode = "Internal Error !!!",
                            msgString = string.Format("Quét thẻ thành công! Mời xe : \"{0}\" vào !", checkingModel.VehicleNumber),
                        }
                    } :
                    new ActionMessage {
                        isSuccess = false,
                        err = new ErorrMssage
                        {
                            msgCode = "Internal Error !!!",
                            msgString = "Quét thẻ thất bại",
                        }
                    });
                }
                return ret;
            }
            else
            {
                ActionMessage ret = new ActionMessage();
                ret.isSuccess = false;
                ret.err.msgCode = "Internal Error !!!";
                ret.err.msgString = "Key hoặc token không chính xác";
                return ret;
            }
        }

        // PUT api/<CheckingScrapController>
        [HttpPut("{rfid}")]
        public ActionMessage SaveCheckingScrapOut([FromHeader] string key, [FromHeader] string token, string rfid, string outGate , Guid userID)
        {
            if (Encrypt.checkToken(token, key))
            {
                ActionMessage ret = new ActionMessage();

                var item = CheckingScrapService.GetInstance().GetCheckingScrap(rfid, false);
                if (item.Count == 0)
                {
                    ret.isSuccess = false;
                    ret.err.msgCode = "Internal Error !!!";
                    ret.err.msgString = "Xe đang được sử dụng";
                }
                else
                {
                    var checkingModel = item.FirstOrDefault();

                    //checkingModel.CheckingScrapId = Guid.NewGuid();
                    //checkingModel.User1Id = userID;
                    //checkingModel.InHourGuard = DateTime.Now;
                    //checkingModel.RFID = input.RFID.Replace("http://", "");
                    //checkingModel.VehicleNumber = input.BienSoXe;

                    //checkingModel.DriverName = input.TenTaiXe;
                    //checkingModel.DriverIdCard = input.CMND;
                    //checkingModel.GiaoNhan = input.GiaoNhan;
                    //checkingModel.InGateId = input.SelectedGate;
                    //checkingModel.Note1 = input.Note;
                    //checkingModel.Step = ConstantStepKL._1VAOCONG;
                    //checkingModel.IsDone = false;

                    checkingModel.User5Id = userID;
                    checkingModel.IsDone = true;
                    checkingModel.Step = ConstantStepKL._6RAKHOICONG;
                    checkingModel.OutGateId = outGate;
                    checkingModel.OutHourGuard = DateTime.Now;

                    int result = CheckingScrapService.GetInstance().UpdateCheckingScrap(checkingModel);

                    return ((result == 1) ?
                    new ActionMessage
                    {
                        isSuccess = true,
                        err = new ErorrMssage
                        {
                            msgCode = "Internal Error !!!",
                            msgString = string.Format("Quét thẻ thành công! Mời xe \"{0}\" ra", checkingModel.VehicleNumber),
                        }
                    } :
                    new ActionMessage
                    {
                        isSuccess = false,
                        err = new ErorrMssage
                        {
                            msgCode = "Internal Error !!!",
                            msgString = string.Format("Quét thẻ thất bại!"),
                        }
                    });
                }
                return ret;
            }
            else
            {
                ActionMessage ret = new ActionMessage();
                ret.isSuccess = false;
                ret.err.msgCode = "Internal Error !!!";
                ret.err.msgString = "Key hoặc token không chính xác";
                return ret;
            }
        }

        // DELETE api/<CheckingScrapController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
