using AutoMapper;
using DeveloperAssignment.BAL.Contracts;
using DeveloperAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IItemsService _serviceCustomerItems;
        private readonly IMapper _mapper;

        public ItemsController(IConfiguration configuration, IItemsService serviceCustomerItems, IMapper mapper)
        {
            _configuration = configuration;
            _serviceCustomerItems = serviceCustomerItems;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetItems")]
        public IEnumerable<Item> GetItems()
        {
            return _mapper.Map<List<Item>>(_serviceCustomerItems.GetAllItems())
                .OrderBy(x => x.Category).ToArray();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _serviceCustomerItems.DeleteItem(id);
        }

        [HttpPost]
        [Route("AddItem")]
        public void AddItem([FromBody]Item item)
        {
            _serviceCustomerItems.AddItem(_mapper.Map<DAL.Models.ItemDTO>(item));
        }
    }
}
