using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Entities;

namespace DataPlus.Bar.Repository
{
    public class WrapperRepository : IWrapperRepository
    {
        private RepositoryContext _repoContext;
        private IProductRepository _product;
        private IIngredientRepository _ingredient;
        private IClientRepository _client;
        private IOrderRepository _order;
        private IOrderItemRepository _orderItem;
        private IPaymentRepository _payment;
        private ITableRepository _table;
        
        public IClientRepository Client
        {
            get
            {
                _client = _client == null ? new ClientRepository(_repoContext) : _client;
                return _client;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                _order = _order == null ? new OrderRepository(_repoContext) : _order;
                return _order;
            }
        }

        public IOrderItemRepository OrderItem
        {
            get
            {
                _orderItem = _orderItem == null ? new OrderItemRepository(_repoContext) : _orderItem;
                return _orderItem;
            }
        }

        public IPaymentRepository Payment
        {
            get
            {
                _payment = _payment == null ? new PaymentRepository(_repoContext) : _payment;
                return _payment;
            }
        }

        public ITableRepository Table
        {
            get
            {
                _table = _table == null ? new TableRepository(_repoContext) : _table;
                return _table;
            }
        }

        public IProductRepository Product
        {
            get
            {
                _product = _product == null ? new ProductRepository(_repoContext) : _product;
                return _product;
            }
        }

        public IIngredientRepository Ingredient
        {
            get
            {
                _ingredient = _ingredient == null ? new IngredientRepository(_repoContext) : _ingredient;
                return _ingredient;
            }
        }

        public WrapperRepository(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
