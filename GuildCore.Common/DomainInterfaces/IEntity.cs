using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Common.DomainInterfaces
{
    public interface IEntity
    {
        /// <summary>
        /// 实体Id
        /// </summary>
        Guid Id { get; set; }

    }
}
