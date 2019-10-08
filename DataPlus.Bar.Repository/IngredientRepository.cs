using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;
using DataPlus.Bar.Entities.Models;

namespace DataPlus.Bar.Repository
{
    public class IngredientRepository: RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
