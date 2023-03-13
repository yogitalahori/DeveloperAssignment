using DeveloperAssignment.DAL.Contracts;
using DeveloperAssignment.DAL.Data;
using DeveloperAssignment.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperAssignment.DAL.Repositories
{
    public class ItemRepository : IRepository<ItemDTO>
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(ItemDTO _object)
        {
            try
            {
                if (_object != null)
                {
                    _dbContext.Items.Add(_object);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                var item = _dbContext.Items.FirstOrDefault(item => item.ItemId == Id);
                if (item != null)
                {
                    _dbContext.Items.Remove(item);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            try
            {
                var obj = _dbContext.Items.Include(x => x.Category).ToList();
                if (obj != null)
                    return obj;
                else
                    return Enumerable.Empty<ItemDTO>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ItemDTO GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemDTO _object)
        {
            throw new NotImplementedException();
        }
    }
}
