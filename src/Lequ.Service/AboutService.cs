﻿using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model.Models;

namespace Lequ.Service
{
    public class AboutService : BaseService<About>, IAboutService
    {
        public AboutService(IAboutRepository repository) : base(repository)
        {
        }
    }
}