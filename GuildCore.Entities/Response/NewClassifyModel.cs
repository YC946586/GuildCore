﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Entities.Response
{
   public  class NewClassifyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Sort { get; set; }

        public string Remark { get; set; }
    }
}