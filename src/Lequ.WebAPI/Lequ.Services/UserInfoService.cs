using System;
using Lequ.IRepository;
using Lequ.IServices;
using Lequ.Models;

namespace Lequ.Services
{
    public class UserInfoService: ServiceBase<UserInfo, int>, IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            base.repositoryBase = userInfoRepository;
            _userInfoRepository = userInfoRepository;
        }
    }
}

