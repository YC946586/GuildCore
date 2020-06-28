using GuildCore.Common;
using GuildCore.Common.RedisHelper;
using GuildCore.Domain.DomainService;
using GuildCore.Domain.Model.Entity;
using GuildCore.Domain.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GuildCore.Infrastructure.DomainService
{
    /// <summary>
    /// 登录领域服务
    /// </summary>
    public class LoginDomainService : ILoginDomainService
    {

        private readonly IBaseRepository<UserInfo> _userRepository;
       
        public LoginDomainService(IBaseRepository<UserInfo> userRepository )
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<HeaderResult<string>> VerificationUserLogin(string username, string password)
        {
            var user = await _userRepository.WhereLoadEntityAsNoTrackingAsync(e => e.UserName == username);
            if (user != null)
            {
                if (user.IsDisable == true)
                {
                    return new HeaderResult<string> { IsSucceed = false, Message = "用户处于禁用状态！" };
                }
                var userPwd = user.UserPassword;
                if (userPwd == password)
                {
                    
                    RedisHelper.SetStringKey(user.Id.ToString() + "Token", user.UserName);

                    //开启一个异步线程获取权限缓存到Redis中
                    Thread thread = new Thread(new ThreadStart(SetRedisPermission));

                    thread.Start();

                    return new HeaderResult<string> { IsSucceed = true, Message = "登录成功！", Result = user.UserName };
                }
                else
                {
                    return new HeaderResult<string> { IsSucceed = false, Message = "密码错误！" };
                }
            }
            else
            {
                return new HeaderResult<string> { IsSucceed = false, Message = "用户名错误！" };
            }

        }

        /// <summary>
        /// 获取权限放到Redis中
        /// </summary>
        public void SetRedisPermission()
        {
            //var userPermission = _userRepository.GetModeListlBySql(@"SELECT DISTINCT ro.Id FROM UserInfo u 
            //LEFT JOIN UserUnGroupInfo ug ON u.Id = ug.UserId
            //LEFT JOIN UserGroupInfo g ON ug.UserGroupId = g.Id
            //LEFT JOIN UserGroupUnRoleInfo ugr ON g.Id = ugr.UserGroupId
            //LEFT JOIN RoleInfo r ON ugr.RoleId = r.Id
            //LEFT JOIN UserUnRoleInfo ur ON u.Id = ur.UserId
            //LEFT JOIN RoleInfo ro ON ur.RoleId = ro.Id");
            var user = _userRepository.LoadEntityAll();
            RedisHelper.HashSet("user88", user, e => e.UserName);
        }

    }
}
