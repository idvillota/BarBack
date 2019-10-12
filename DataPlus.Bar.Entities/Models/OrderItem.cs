using System;
using System.Collections.Generic;
using System.Text;

namespace DataPlus.Bar.Entities.Models
{
    public class OrderItem : IEntity
    {
        public Guid Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int OldQuantity { get; set; }

        public int OrderId { get; set; }

        public string Observation { get; set; }

        public long Total { get; set; }

        public bool IsPrinted { get; set; }

        public double Cost { get; set; }
    }
}
