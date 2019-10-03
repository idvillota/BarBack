using System.Collections.Generic;
using System.Linq;
using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;
using DataPlus.Bar.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPlus.Bar.Repository
{
    public class OwnerRepository: RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }

        //public IList<Owner> GetAllWithAccounts()
        //{
        //    //var data = context.Blogs.Include(x => x.Post).ThenInclude(x => x.Author)



        //    var owners = this.RepositoryContext.Owners.Include(x => x.Accounts);

        //    return owners.ToList();
        //}
    }
}
