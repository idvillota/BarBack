using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;
using DataPlus.Bar.Entities.Models;

namespace DataPlus.Bar.Repository
{
    public class ClientRepository: RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
