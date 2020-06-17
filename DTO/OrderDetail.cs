using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.DTO
{
    public class OrderDetail
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        public int IdCustomer { get; set; }
        public string CustomerName { get; set; }
        public int IdConfectionery { get; set; }
        public string ConfectioneryName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
        public string Type { get; set; }
    }
}
