using DataPlus.Bar.Entities.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataPlus.Bar.Entities.Models
{
    public class Order
    {
        #region Properties

        public int ID { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
        
        public Client Client { get; set; }

        public int ClientId { get; set; }

        public DateTime Date { get; set; }

        public long Total { get; set; }
        
        public Table Table { get; set; }

        public int TableId { get; set; }

        public EPaymentStatus PaymentStatus { get; set; }
        
        public Payment Payment { get; set; }

        public int PaymentId { get; set; }

        public string Waiter { get; set; }

        #endregion
    }
}
