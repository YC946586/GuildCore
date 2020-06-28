using GuildCore.Application.User.Dto;
using GuildCore.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuildCore.Application.User
{
    /// <summary>
    /// 用户
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        Task<HeaderResult<List<UserDto>>> GetUserList(SearchUserDto input);
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userGroupId"></param>
        /// <returns></returns>
        Task<HeaderResult<string>> DelUserGroup(string userGroupId);
        /// <summary>
        /// 根据角色查询出已经分配的用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<HeaderResult<List<Guid>>> GetUserUnRoleList(Guid roleId);

        /// <summary>
        /// 分配用户组角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userGroupIdStr"></param>
        /// <returns></returns>
        Task<HeaderResult<string>> AssignGroupRole(Guid roleId, string userGroupIdStr);

    }
}
