using DataPlus.Bar.Entities.Models.Enumerations;
using System;

namespace DataPlus.Bar.Entities.Models
{
    public class Ingredient: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public float Value { get; set; }
        public EIngredientCategory Category { get; set; }
        public EIngredientPresentation Presentation { get; set; }
    }
}
