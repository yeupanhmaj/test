using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Common
{
    public class SqlResult
    {

    }
    public enum SQL_RESULT_CODE
    {
        [Description("Thành công")]
        success = 1,
        [Description("Thất bại")]
        fail = 0,
    }
}
