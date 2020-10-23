using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.Common
{
    public class Encrypt
    {   /// <summary>
        /// mã hóa MD5
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string token = "45FCC8F419313AZ559E2DED09B9AF94";
        public static string key = "19ac858c-6517-45ce-a22e-095aff5cffff";
        public static Boolean checkToken(string token,string key)
        {
            return (token.Equals(Encrypt.token) && key.Equals(Encrypt.key)) ? true : false;           
        }
        public static string encryptMD5(string data)
        {   
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));

            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
