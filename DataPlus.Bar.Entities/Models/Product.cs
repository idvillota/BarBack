using System;

namespace DataPlus.Bar.Entities.Models
{
    public class Product: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SalePrice { get; set; }
        public float CostPrice { get; set; }
        public int Quantity { get; set; }
    }
}
