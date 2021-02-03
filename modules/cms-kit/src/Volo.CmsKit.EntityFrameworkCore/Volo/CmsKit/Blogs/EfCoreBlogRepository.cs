﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.CmsKit.EntityFrameworkCore;

namespace Volo.CmsKit.Blogs
{
    public class EfCoreBlogRepository : EfCoreRepository<ICmsKitDbContext, Blog, Guid>, IBlogRepository
    {
        public EfCoreBlogRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<bool> ExistsAsync(Guid blogId)
        {
            return await (await GetQueryableAsync()).AnyAsync(x => x.Id == blogId);
        }
    }
}
