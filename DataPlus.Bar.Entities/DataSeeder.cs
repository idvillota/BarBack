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
            CreateCubes();
            CreateOwners();
            CreateIngredients();
            _context.SaveChanges();
            //CreateAccounts();
            
        }

        //public void CreateAccounts()
        //{
        //    var owner1 = _context.Owners.First(o => o.Name == "Owner 1");
        //    AddnewAccount(new Account
        //    {
        //        AccountType = "AccountType1",
        //        Owner = owner1,
        //        OwnerId = owner1.Id
        //    });
        //    AddnewAccount(new Account
        //    {
        //        AccountType = "AccountType2",
        //        Owner = owner1,
        //        OwnerId = owner1.Id
        //    });
        //}

        private void AddnewAccount(Account account)
        {
            var existingAccount = _context.Accounts.FirstOrDefault(a => a.AccountType == account.AccountType);
            if (existingAccount == null)
                _context.Accounts.Add(account);
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

        public void CreateOwners()
        {
            AddnewOwner(new Owner
            {
                Name = "Owner 1",
                Address = "Address 1",
                DateOfBirth = new DateTime(1980, 1, 1)
            });
            AddnewOwner(new Owner
            {
                Name = "Owner 5",
                Address = "Address 5",
                DateOfBirth = new DateTime(1980, 5, 5)
            });
            AddnewOwner(new Owner
            {
                Name = "Owner 2",
                Address = "Address 2",
                DateOfBirth = new DateTime(1980, 2, 2)
            });
            AddnewOwner(new Owner
            {
                Name = "Owner 6",
                Address = "Address 6",
                DateOfBirth = new DateTime(1980, 6, 6)
            });
            AddnewOwner(new Owner
            {
                Name = "Owner 4",
                Address = "Address 4",
                DateOfBirth = new DateTime(1980, 4, 4)
            });
        }

        private void AddnewOwner(Owner owner)
        {
            var existingOwner = _context.Owners.FirstOrDefault(o => o.Name == owner.Name);
            if (existingOwner == null)
                _context.Owners.Add(owner);
        }

        public void CreateCubes()
        {
            AddNewCube(new Cube
            {
                Size = 2,
            });
            AddNewCube(new Cube
            {
                Size = 3,
            });
            AddNewCube(new Cube
            {
                Size = 4,
            });
        }

        private void AddNewCube(Cube cube)
        {
            var existingCube = _context.Cubes.FirstOrDefault(c => c.Size == cube.Size);

            if (existingCube == null)
                _context.Cubes.Add(cube);
        }
    }
}
