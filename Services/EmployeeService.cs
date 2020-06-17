using ConfectioneryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.Services
{
    public class EmployeeService:IDataService<Employee>
    {
        readonly ConfectioneryDbContext _dbContext;

        public EmployeeService(ConfectioneryDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employee.ToList();
        }

        public Employee GetById(int id)
        {
            return _dbContext.Employee
                  .FirstOrDefault(e => e.IdEmployee == id);
        }
        public void Add(Employee entity)
        {
            _dbContext.Employee.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.Name = entity.Name;
            employee.Surname = entity.Surname;
            _dbContext.Employee.Update(employee);
            _dbContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _dbContext.Employee.Remove(employee);
            _dbContext.SaveChanges();
        }
    }
}
