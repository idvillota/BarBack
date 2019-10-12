using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;
using DataPlus.Bar.Entities.Models;

namespace DataPlus.Bar.Repository
{
    public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
