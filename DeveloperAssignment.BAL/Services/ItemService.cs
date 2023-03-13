using DeveloperAssignment.BAL.Contracts;
using DeveloperAssignment.DAL.Contracts;
using DeveloperAssignment.DAL.Models;

namespace DeveloperAssignment.BAL.Services
{
    public class ItemService : IItemsService
    {
        public readonly IRepository<ItemDTO> _repository;

        public ItemService(IRepository<ItemDTO> repository)
        {
            _repository = repository;
        }

        public void AddItem(ItemDTO item)
        {
            _repository.Create(item);
        }

        public void DeleteItem(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ItemDTO> GetAllItems()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
