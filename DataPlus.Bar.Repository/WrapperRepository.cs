using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;

namespace DataPlus.Bar.Repository
{
    public class WrapperRepository : IWrapperRepository
    {
        private RepositoryContext _repoContext;
        public ICubeRepository _cube; 

        public ICubeRepository Cube
        {
            get
            {
                _cube = _cube == null ? new CubeRepository(_repoContext) : _cube;
                return _cube;
            }
        }

        public WrapperRepository(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
