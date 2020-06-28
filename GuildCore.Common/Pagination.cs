using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Common
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 条数
        /// </summary>
        public int Pagesize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
    }
}
