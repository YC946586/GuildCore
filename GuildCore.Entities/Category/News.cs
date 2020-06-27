using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Entities.Category
{
    public class News
    {
        public News()
        {
            this.Comments = new HashSet<NewComment>();
        }
        public int Id { get; set; }

        public int NewClassifyId { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }

        public string Contents { get; set; }
     
        public DateTime Date { get; set; }

        public string Remark { get; set; }


        public virtual NewClassify NewClassify { get; set; } 

        public virtual ICollection<NewComment> Comments { get; set; }
    }
}
