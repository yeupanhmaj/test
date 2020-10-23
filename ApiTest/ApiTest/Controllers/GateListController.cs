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
    public class GateListController : ControllerBase
    {
        // GET: api/<GateListController>
        [HttpGet]
        public ListResponeMessage<GateViewModel> GetGateList([FromHeader] string key, [FromHeader] string token)
        {
            if (Encrypt.checkToken(token, key))
            {
                ListResponeMessage<GateViewModel> ret = new ListResponeMessage<GateViewModel>();
                try
                {
                    ret.isSuccess = true;
                    ret.data = GateListService.GetInstance().GetGateList();
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
                ListResponeMessage<GateViewModel> ret = new ListResponeMessage<GateViewModel>();
                ret.isSuccess = false;
                ret.err.msgCode = "Internal Error !!!";
                ret.err.msgString = "Key hoặc token không chính xác";
                return ret;
            }    
        }

        // GET api/<GateListController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GateListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GateListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GateListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
