using DataPlus.Bar.Entities.Models;
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
            CreateCubes();
            CreateOwners();
            _context.SaveChanges();
            //CreateAccounts();
            _context.SaveChanges();
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
