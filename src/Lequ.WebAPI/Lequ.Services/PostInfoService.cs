using System;
using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model;

namespace Lequ.Services
{
    public class PostInfoService : ServiceBase<PostInfo, int>, IPostInfoService
    {
        private readonly IPostInfoRepository _postInfoRepository;
        public PostInfoService(IPostInfoRepository postInfoRepository)
        {
            base.repositoryBase = postInfoRepository;
            _postInfoRepository = postInfoRepository;
        }
    }
}

