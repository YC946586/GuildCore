using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Entities.Category
{
    public class NewComment
    {
        public int Id { get; set; }

        public int NewId { get; set; }

        public string Contents { get; set; }

        public DateTime EditDate { get; set; }

        public string Remark { get; set; }


        public virtual News News { get; set; }
    }
}
