using GuildCore.Common;
using System;
using System.Threading.Tasks;

namespace GuildCore.Domain.DomainService
{
    public interface ILoginDomainService
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<HeaderResult<string>> VerificationUserLogin(string username, string password);
    }
}
