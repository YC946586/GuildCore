using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuildCore.Common.DomainInterfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
