using GuildCore.Application.User.Dto;
using GuildCore.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuildCore.Application.User
{
    public interface ILoginService
    {
        Task<HeaderResult<string>> VerificationUserLogin(UserModelDto input);
    }
}
