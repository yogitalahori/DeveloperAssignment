using DeveloperAssignment.DAL.Models;

namespace DeveloperAssignment.BAL.Contracts
{
    public interface IItemsService
    {
        public IEnumerable<ItemDTO> GetAllItems();
        public void DeleteItem(int id);
        public void AddItem(ItemDTO item);
    }
}
