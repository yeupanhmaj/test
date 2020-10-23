using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Model
{
    public class SingleResponeMessage<T>
    {
        public SingleResponeMessage()
        {
            err = new ErorrMssage();
        }
        public bool isSuccess { get; set; }
        public T item { get; set; }
        public ErorrMssage err { get; set; }
    }
}
