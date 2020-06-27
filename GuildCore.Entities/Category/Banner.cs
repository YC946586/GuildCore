using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GuildCore.Entities.Category
{
    [Table("Banner")]
    public class Banner
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public string Remark { get; set; }

        public DateTime addDate { get; set; }
    }
}
