using GuildCore.Application.User.Dto;
using GuildCore.Common;
using GuildCore.Domain.DomainService;
using GuildCore.Domain.Model.Entity;
using GuildCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuildCore.Application.User
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginService : ILoginService
    {
        private readonly IBaseRepository<UserInfo> _userRepository;
        private readonly ILoginDomainService _loginDomainService;

        public LoginService(IBaseRepository<UserInfo> userRepository, ILoginDomainService loginDomainService)
        {
            _userRepository = userRepository;
            _loginDomainService = loginDomainService;
        }



        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<HeaderResult<string>> VerificationUserLogin(UserModelDto input)
        {
            var result = await _loginDomainService.VerificationUserLogin(input.Username, input.Password);

            return result;
        }
    }
}
