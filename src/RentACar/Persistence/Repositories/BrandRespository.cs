using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BrandRespository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
    {
        public BrandRespository(BaseDbContext context) : base(context)
        {
        }
    }
}