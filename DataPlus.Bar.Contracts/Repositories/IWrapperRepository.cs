
namespace DataPlus.Bar.Contracts.Repositories
{
    public interface IWrapperRepository
    {
        ICubeRepository Cube { get; }
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }
        IProductRepository Product { get; }
        IIngredientRepository Ingredient { get; }
        void Save();
    }
}
