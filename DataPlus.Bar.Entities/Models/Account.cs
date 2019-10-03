using System;

namespace DataPlus.Bar.Entities.Models
{
    public class Account : IEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string AccountType { get; set; }
        public Guid OwnerId { get; set; }
    }
}
