using DataPlus.Bar.Entities.Models.Enumerations;
using System;
using System.Collections.Generic;

namespace DataPlus.Bar.Entities.Models
{
    public class Payment: IEntity
    {
        public Guid Id{ get; set; }

        public DateTime Date { get; set; }

        public List<Order> Orders { get; set; }

        public float Total { get; set; }

        public float Discount { get; set; }

        public EPaymentStatus PaymentStatus { get; set; }

        public long Number { get; set; }

        public string Prefix { get; set; }
        
        public float Receive { get; set; }

        public float ReceiveCard { get; set; }

        public float Change { get; set; }

        public float Credit { get; set; }

        public string Voucher { get; set; }

        public string Cashier { get; set; }
        
        public string Iterator { get; set; }
        
    }
}
