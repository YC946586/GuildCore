using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GuildCore.Entities.Category
{
    [Table("Category")]
    public class Category
    {
        public int code { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMenu { get; set; }
    }
}
