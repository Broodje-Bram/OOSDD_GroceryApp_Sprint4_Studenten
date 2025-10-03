using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class BoughtProductsService : IBoughtProductsService
    {
        private readonly IGroceryListItemsRepository _groceryListItemsRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGroceryListRepository _groceryListRepository;
        public BoughtProductsService(IGroceryListItemsRepository groceryListItemsRepository, IGroceryListRepository groceryListRepository, IClientRepository clientRepository, IProductRepository productRepository)
        {
            _groceryListItemsRepository = groceryListItemsRepository;
            _groceryListRepository = groceryListRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }
        public List<BoughtProducts> Get(int? productId)
        {
            var items = _groceryListItemsRepository.GetAll();
            if (productId.HasValue)
            {
                items = items.Where(i => i.ProductId == productId.Value).ToList();
            }

            var list = new List<BoughtProducts>();
            foreach (var item in items)
            {
                var gl = _groceryListRepository.Get(item.GroceryListId);
                if (gl == null) continue;
                var client = _clientRepository.Get(gl.ClientId);
                var product = _productRepository.Get(item.ProductId);
                if (client == null || product == null) continue;
                list.Add(new BoughtProducts(client, gl, product));
            }
            return list;
        }
    }
}