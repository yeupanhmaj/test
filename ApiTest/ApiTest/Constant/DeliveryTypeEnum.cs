using System.ComponentModel.DataAnnotations;

namespace Constant.Enums
{
    public enum DeliveryTypeEnum
    {
        [Display(Name = "Giao")]
        Delivery = 1,
        [Display(Name = "Nhận")]
        Receive = 2
    }
}
