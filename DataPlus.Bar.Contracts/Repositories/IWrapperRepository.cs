
namespace DataPlus.Bar.Contracts.Repositories
{
    public interface IWrapperRepository
    {
        IProductRepository Product { get; }
        IIngredientRepository Ingredient { get; }
        IClientRepository Client { get; }
        IOrderRepository Order { get; }
        IOrderItemRepository OrderItem { get; }
        IPaymentRepository Payment { get; }
        ITableRepository Table { get; }
        void Save();
    }
}
