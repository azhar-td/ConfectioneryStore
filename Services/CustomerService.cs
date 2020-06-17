using ConfectioneryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.Services
{
    public class CustomerService:IDataService<Customer>
    {
        readonly ConfectioneryDbContext _dbContext;

        public CustomerService(ConfectioneryDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customer.ToList();
        }

        public Customer GetById(int id)
        {
            return _dbContext.Customer
                  .FirstOrDefault(e => e.IdCustomer == id);
        }
        public void Add(Customer entity)
        {
            _dbContext.Customer.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Customer customer, Customer entity)
        {
            customer.Name = entity.Name;
            customer.Surname = entity.Surname;
            _dbContext.Customer.Update(customer);
            _dbContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _dbContext.Customer.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}
