using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Entities.Request
{
    public class AddNewClassify
    {
        public string Name { get; set; }

        public int Sort { get; set; }

        public string Remark { get; set; }
    }
}
