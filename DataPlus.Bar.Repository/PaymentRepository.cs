using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;
using DataPlus.Bar.Entities.Models;

namespace DataPlus.Bar.Repository
{
    public class PaymentRepository: RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
