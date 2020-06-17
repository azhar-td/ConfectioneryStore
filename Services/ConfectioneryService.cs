using ConfectioneryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.Services
{
    public class ConfectioneryService:IDataService<Confectionery>
    {
        readonly ConfectioneryDbContext _dbContext;

        public ConfectioneryService(ConfectioneryDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Confectionery> GetAll()
        {
            return _dbContext.Confectionery.ToList();
        }

        public Confectionery GetById(int id)
        {
            return _dbContext.Confectionery
                  .FirstOrDefault(e => e.IdConfectionery == id);
        }
        public void Add(Confectionery entity)
        {
            _dbContext.Confectionery.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Confectionery confectionery, Confectionery entity)
        {
            confectionery.Name = entity.Name;
            confectionery.PricePerItem = entity.PricePerItem;
            confectionery.Type = entity.Type;
            _dbContext.Confectionery.Update(confectionery);
            _dbContext.SaveChanges();
        }

        public void Delete(Confectionery confectionery)
        {
            _dbContext.Confectionery.Remove(confectionery);
            _dbContext.SaveChanges();
        }
    }
}
