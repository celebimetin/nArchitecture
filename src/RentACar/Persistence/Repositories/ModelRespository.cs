using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    internal class ModelRespository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
    {
        public ModelRespository(BaseDbContext context) : base(context)
        {
        }
    }
}