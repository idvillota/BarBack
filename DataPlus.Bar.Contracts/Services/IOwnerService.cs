using DataPlus.Bar.Entities.ExtendedModels;
using DataPlus.Bar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataPlus.Bar.Contracts.Services
{
    public interface IOwnerService: IEntityService<Owner>
    {
        IList<OwnerExtended> GetAllWithAccounts();
        OwnerExtended GetByIdWithDetails(Guid ownerId);
    }
}
