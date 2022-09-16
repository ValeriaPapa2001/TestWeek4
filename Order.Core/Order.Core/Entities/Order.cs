using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace OrderManager.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }

        public string ProductCode { get; set; }
        public decimal Amount { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }

    }
}
