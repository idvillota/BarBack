using DataPlus.Bar.Entities.Models.Enumerations;
using System;

namespace DataPlus.Bar.Entities.Models
{
    public class Person: IEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DocumentNumber { get; set; }

        public EDocumentType DocumentType { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
