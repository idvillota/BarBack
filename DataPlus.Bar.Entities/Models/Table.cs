using DataPlus.Bar.Entities.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataPlus.Bar.Entities.Models
{
    public class Table: IEntity
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public int Chairs { get; set; }

        public ETableStatus Status { get; set; }
        
    }
}
