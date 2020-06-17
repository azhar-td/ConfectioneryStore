using ConfectioneryStore.DTO;
using ConfectioneryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.Services
{
    public class OrderService:IDataService<Order>,IDataServicePro<OrderDetail>
    {
        readonly ConfectioneryDbContext _dbContext;

        public OrderService(ConfectioneryDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Order.ToList();
        }

        public IEnumerable<OrderDetail> GetAllOrdersWithDetail()
        {
            var query=from o in _dbContext.Order
                      join
                      cus in _dbContext.Customer
                      on
                      o.IdCustomer equals cus.IdCustomer
                      join
                      conO in _dbContext.ConfectioneryOrder
                      on
                      o.IdOrder equals conO.IdOrder
                      join
                      con in _dbContext.Confectionery
                      on
                      conO.IdConfectionery equals con.IdConfectionery
                      select
                      (new OrderDetail {
                          IdOrder=o.IdOrder,
                          DateAccepted=o.DateAccepted,
                          DateFinished=o.DateFinished,
                          Notes=o.Notes,
                          IdCustomer=cus.IdCustomer,
                          CustomerName=cus.Name,
                          IdConfectionery=con.IdConfectionery,
                          ConfectioneryName=con.Name,
                          Quantity = conO.Quantity,
                          PricePerItem =con.PricePerItem,
                          Type=con.Type
                      });
            return query.ToList();
        }
        public OrderDetail GetOrderWithDetailByCustomer(string cusName)
        {
            var query = from o in _dbContext.Order
                        join
                        cus in _dbContext.Customer
                        on
                        o.IdCustomer equals cus.IdCustomer
                        join
                        conO in _dbContext.ConfectioneryOrder
                        on
                        o.IdOrder equals conO.IdOrder
                        join
                        con in _dbContext.Confectionery
                        on
                        conO.IdConfectionery equals con.IdConfectionery
                        where
                        cus.Name.ToLower() == cusName.ToLower()
                        select
                        (new OrderDetail
                        {
                            IdOrder = o.IdOrder,
                            DateAccepted = o.DateAccepted,
                            DateFinished = o.DateFinished,
                            Notes = o.Notes,
                            IdCustomer = cus.IdCustomer,
                            CustomerName = cus.Name,
                            IdConfectionery = con.IdConfectionery,
                            ConfectioneryName = con.Name,
                            Quantity = conO.Quantity,
                            PricePerItem = con.PricePerItem,
                            Type = con.Type
                        }); ;
            return query.FirstOrDefault();
        }

        public Order GetById(int id)
        {
            return _dbContext.Order
                  .FirstOrDefault(e => e.IdOrder == id);
        }
        public void Add(Order entity)
        {
            _dbContext.Order.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Order order, Order entity)
        {
            order.DateAccepted = entity.DateAccepted;
            order.DateFinished = entity.DateFinished;
            order.Notes = entity.Notes;
            _dbContext.Order.Update(order);
            _dbContext.SaveChanges();
        }

        public void Delete(Order order)
        {
            _dbContext.Order.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}
