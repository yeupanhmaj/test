using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Model
{
    public class ProductModel
    {
       public Guid ProductId { get; set; }
       public string ProductCode{ get; set; }
       public string ProductName { get; set; }
       public string UnitCode { get; set; }
       public decimal MinSingleWeight{ get; set; }
       public decimal MaxSingleWeight { get; set; }
       public bool isSAPData{ get; set; }
       public DateTime CreatedTime{ get; set; }
       public DateTime LastEditedTime{ get; set; }
       public bool Actived{ get; set; }
       public bool isShowMobile{ get; set; }
    }
}
