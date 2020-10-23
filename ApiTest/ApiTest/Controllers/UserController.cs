using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Common;
using ApiTest.Model;
using ApiTest.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        //public ListResponeMessage<string> Get()
        //{
        //    ListResponeMessage<string> result = new ListResponeMessage<string>();
        //    string[] data = { "value 1", "value 2" };
        //    result.data = data.ToList();
        //    result.isSuccess = true;
        //    result.err = null;
        //    result.totalRecords = 2;
        //    return result;
        //}

        // GET api/<TestController>/5
        [HttpGet()]
        public SingleResponeMessage<UserModel> GetUser([FromHeader] string key, [FromHeader] string token, string id,string password)
        {
            if( Encrypt.checkToken(token, key))
            {
                SingleResponeMessage<UserModel> ret = new SingleResponeMessage<UserModel>();
                try
                {
                    string passwordEncrypt = Encrypt.encryptMD5(password);
                    UserModel item = UserService.GetInstance().GetUser(id);
                    if (item == null)
                    {
                        ret.isSuccess = false;
                        ret.err.msgCode = "001";
                        ret.err.msgString = "Tài khoản chưa đăng ký!";
                        return ret;
                    }
                    if(!string.IsNullOrEmpty(item.PasswordEnscrypt))
                    {
                        if (item.PasswordEnscrypt.Equals(passwordEncrypt))
                        {
                            ret.item = item;
                            ret.isSuccess = true;
                        }
                    }    
                    else
                    {
                        ret.item = null;
                        ret.isSuccess = false;
                        ret.err.msgString = "Sai tên đăng nhập hoặc mật khẩu!";
                    }    
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
                SingleResponeMessage<UserModel> ret = new SingleResponeMessage<UserModel>();
                ret.isSuccess = false;
                ret.err.msgCode = "Internal Error !!!";
                ret.err.msgString = "Key hoặc token không chính xác";
                return ret;
            }
           
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
