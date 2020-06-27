using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Entities.Response
{
    /// <summary>
    /// 返回
    /// </summary>
    public class ResponseModel
    {
        public int Code { get; set; }

        public string result { get; set; }


        public dynamic data { get; set; }
    }
}
