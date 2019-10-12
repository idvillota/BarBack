using DataPlus.Bar.Entities.Models;
using DataPlus.Bar.Entities.Models.Enumerations;
using System;
using System.Linq;

namespace DataPlus.Bar.Entities
{
    public class DataSeeder
    {
        private RepositoryContext _context;

        public DataSeeder(RepositoryContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            CreateProducts();
            CreateIngredients();
            CreateClients();
            CreateTables();
            CreatePayments();
            _context.SaveChanges();
            
        }

        private void AddNewProduct(Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct == null)
                _context.Products.Add(product);
        }

        private void AddNewIngredient(Ingredient ingredient)
        {
            var existingIngredient = _context.Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
            if (existingIngredient == null)
                _context.Ingredients.Add(ingredient);
        }

        private void AddNewClient(Client client)
        {
            var existingClient = _context.Clients.FirstOrDefault(c => c.DocumentNumber == client.DocumentNumber);
            if (existingClient == null)
                _context.Clients.Add(client);
        }

        private void AddNewTable(Table table)
        {
            var existingTable = _context.Tables.FirstOrDefault(t => t.Number == table.Number);
            if (existingTable == null)
                _context.Tables.Add(table);
        }

        private void AddNewPayment(Payment payment)
        {
            var existingPayment = _context.Payments.FirstOrDefault(p => p.Number == payment.Number);
            if (existingPayment == null)
                _context.Payments.Add(payment);
        }

        public void CreatePayments()
        {
            //var product1 = _context.Products.First(p => p.Id != Guid.Empty);

            //AddNewPayment(new Payment
            //{
            //    Number = 1,
            //    Date = DateTime.Now,
            //    PaymentStatus = EPaymentStatus.POR_PAGAR,
            //    Prefix = "AB",

            //});
        }

        public void CreateTables()
        {
            AddNewTable(new Table
            {
                Number = "1",
                Chairs = 4,
                Status = ETableStatus.Libre
            });

            AddNewTable(new Table
            {
                Number = "2",
                Chairs = 4,
                Status = ETableStatus.Libre
            });

            AddNewTable(new Table
            {
                Number = "3",
                Chairs = 4,
                Status = ETableStatus.Libre
            });

            AddNewTable(new Table
            {
                Number = "4",
                Chairs = 4,
                Status = ETableStatus.Libre
            });
        }

        public void CreateClients()
        {
            AddNewClient(new Client
            {
                DocumentType = EDocumentType.CC,
                DocumentNumber = "111111111",
                FirstName = "Pedro",
                LastName = "Perez",
                Email = "pedro@gmail.com",
                PhoneNumber = "3001234567",
                Address = "Calle 1 no 1 - 1"
            });

            AddNewClient(new Client
            {
                DocumentType = EDocumentType.CC,
                DocumentNumber = "2222222",
                FirstName = "Maria",
                LastName = "Diaz",
                Email = "maria@gmail.com",
                PhoneNumber = "3009876541",
                Address = "Calle 2 no 2 - 2"
            });

            AddNewClient(new Client
            {
                DocumentType = EDocumentType.CC,
                DocumentNumber = "333333333",
                FirstName = "Luis",
                LastName = "Moreno",
                Email = "luicito@gmail.com",
                PhoneNumber = "300515151",
                Address = "Calle 3 no 3 - 3"
            });
        }

        public void CreateIngredients()
        {
            AddNewIngredient(new Ingredient
            {
                Name = "Ingredient 1",
                Quantity = 100,
                Value = 150,
                Category = EIngredientCategory.PRODUCTO_TERMINADO,
                Presentation = EIngredientPresentation.UNIDAD
            });

            AddNewIngredient(new Ingredient
            {
                Name = "Ingredient 5",
                Quantity = 500,
                Value = 250,
                Category = EIngredientCategory.PRODUCTO_TERMINADO,
                Presentation = EIngredientPresentation.UNIDAD
            });

            AddNewIngredient(new Ingredient
            {
                Name = "Ingredient 3",
                Quantity = 300,
                Value = 200,
                Category = EIngredientCategory.PRODUCTO_TERMINADO,
                Presentation = EIngredientPresentation.UNIDAD
            });

            AddNewIngredient(new Ingredient
            {
                Name = "Ingredient 2",
                Quantity = 200,
                Value = 550,
                Category = EIngredientCategory.PRODUCTO_TERMINADO,
                Presentation = EIngredientPresentation.UNIDAD
            });

            AddNewIngredient(new Ingredient
            {
                Name = "Ingredient 4",
                Quantity = 400,
                Value = 750,
                Category = EIngredientCategory.PRODUCTO_TERMINADO,
                Presentation = EIngredientPresentation.UNIDAD
            });
        }

        public void CreateProducts()
        {
            AddNewProduct(new Product
            {
                Name = "Product 1",
                Description = "Product 1 Description",
                CostPrice = 1000,
                SalePrice = 2000,
                Quantity = 100
            });
            AddNewProduct(new Product
            {
                Name = "Product 5",
                Description = "Product 5 Description",
                CostPrice = 1200,
                SalePrice = 2100,
                Quantity = 150
            });
            AddNewProduct(new Product
            {
                Name = "Product 3",
                Description = "Product 3 Description",
                CostPrice = 800,
                SalePrice = 1600,
                Quantity = 80
            });
            AddNewProduct(new Product
            {
                Name = "Product 4",
                Description = "Product 4 Description",
                CostPrice = 2000,
                SalePrice = 3000,
                Quantity = 90
            });
            AddNewProduct(new Product
            {
                Name = "Product 2",
                Description = "Product 2 Description",
                CostPrice = 3000,
                SalePrice = 4500,
                Quantity = 160
            });
        }
        
    }
}
