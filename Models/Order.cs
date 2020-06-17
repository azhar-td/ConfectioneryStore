using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.Models
{
    public class Order
    {
        public Order()
        {
            ConfectioneryOrders = new HashSet<ConfectioneryOrder>();
        }

        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }

        public int IdCustomer { get; set; }
        public int IdEmployee { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<ConfectioneryOrder> ConfectioneryOrders { get; set; }
    }
}
