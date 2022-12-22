using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IBrandRepository : IRepository<Brand>, IAsyncRepository<Brand>
    {
    }
}