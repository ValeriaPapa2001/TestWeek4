using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OrderManager.Core.Entities
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CodeClient { get; set; }
        
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public IList<Order> Orders { get; set; }


    }
}
