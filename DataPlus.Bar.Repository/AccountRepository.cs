using System.Collections.Generic;
using System.Linq;
using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;
using DataPlus.Bar.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPlus.Bar.Repository
{
    public class AccountRepository: RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }        
    }
}
