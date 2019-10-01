using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;
using DataPlus.Bar.Entities.Models;

namespace DataPlus.Bar.Repository
{
    public class CubeRepository: RepositoryBase<Cube>, ICubeRepository
    {
        public CubeRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
