using System;

namespace DataPlus.Bar.Entities.Models
{
    public class Owner : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }        
    }
}
