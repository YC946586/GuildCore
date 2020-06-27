using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Entities.Request
{
    public  class AddBanner
    {
        public string Image { get; set; }

        public string Url { get; set; }

        public string Remark { get; set; }
    }
}
