using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GuildCore.Entities.Category
{
    [Table("NewClassify")]
    public class NewClassify
    {
        public NewClassify()
        {
            this.NewsList = new HashSet<News>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Sort { get; set; }

        public string Remark { get; set; }

        public virtual ICollection<News> NewsList { get; set; }
    }
}
