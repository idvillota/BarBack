using System;
using System.Collections.Generic;

namespace DataPlus.Bar.Entities.Models
{
    public class Cube : IEntity
    {
        public Guid Id { get; set; }

        public int Size { get; set; }

        public ICollection<ArrayValue> Array { get; set; }

    }
}
