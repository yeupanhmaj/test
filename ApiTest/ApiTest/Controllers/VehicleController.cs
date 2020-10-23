using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Common;
using ApiTest.Model;
using ApiTest.Service;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        // GET: api/<VehicleController>
        [HttpGet]
        public SingleResponeMessage<VehicleViewModel> GetVehicleInfo([FromHeader] string key, 
            [FromHeader] string token, 
            string vehicleNumber)
        {
            if (Encrypt.checkToken(token, key))
            {
                SingleResponeMessage<VehicleViewModel> ret = new SingleResponeMessage<VehicleViewModel>();
                try
                {                    
                    VehicleViewModel item = VehicleService.GetInstance().GetVehicleInfo(vehicleNumber);
                    if (item == null)
                    {
                        ret.isSuccess = false;
                        ret.err.msgCode = "001";
                        ret.err.msgString = "no  Vehicle found";
                        return ret;
                    }
                    ret.item = item;
                    ret.isSuccess = true;
                }
                catch (Exception ex)
                {
                    ret.isSuccess = false;
                    ret.err.msgCode = "Internal Error !!!";
                    ret.err.msgString = ex.ToString();
                }
                return ret;
            }
            else
            {
                SingleResponeMessage<VehicleViewModel> ret = new SingleResponeMessage<VehicleViewModel>();
                ret.isSuccess = false;
                ret.err.msgCode = "Internal Error !!!";
                ret.err.msgString = "Key hoặc token không chính xác";
                return ret;
            }

        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post(string key,string token,[FromBody] string input, Guid userID)
        {

        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
