using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;
using DataPlus.Bar.Entities.Models;

namespace DataPlus.Bar.Repository
{
    public class TableRepository: RepositoryBase<Table>, ITableRepository
    {
        public TableRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
