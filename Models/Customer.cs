using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
