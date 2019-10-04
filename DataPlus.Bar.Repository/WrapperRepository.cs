using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;

namespace DataPlus.Bar.Repository
{
    public class WrapperRepository : IWrapperRepository
    {
        private RepositoryContext _repoContext;
        private ICubeRepository _cube;
        private IOwnerRepository _owner;
        private IAccountRepository _account;
        private IProductRepository _product;

        public ICubeRepository Cube
        {
            get
            {
                _cube = _cube == null ? new CubeRepository(_repoContext) : _cube;
                return _cube;
            }
        }

        public IOwnerRepository Owner
        {
            get
            {
                _owner = _owner == null ? new OwnerRepository(_repoContext) : _owner;
                return _owner;
            }
        }

        public IProductRepository Product
        {
            get
            {
                _product = _product == null ? new ProductRepository(_repoContext) : _product;
                return _product;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                _account = _account == null ? new AccountRepository(_repoContext) : _account;
                return _account;
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
