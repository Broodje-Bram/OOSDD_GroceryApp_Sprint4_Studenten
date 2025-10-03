using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class GroceryListRepository : IGroceryListRepository
    {
        private readonly List<GroceryList> groceryLists;

        public GroceryListRepository()
        {
            groceryLists = [
                new GroceryList(1, "Boodschappen familieweekend", DateOnly.Parse("2024-12-14"), "#FF6A00", 1),
                new GroceryList(2, "Kerstboodschappen", DateOnly.Parse("2024-12-07"), "#626262", 1),
                new GroceryList(3, "Weekend boodschappen", DateOnly.Parse("2024-11-30"), "#003300", 1),

                new GroceryList(4, "Boodschappen familieweekend", DateOnly.Parse("2024-12-14"), "#FF6A00", 2),
                new GroceryList(5, "Kerstboodschappen", DateOnly.Parse("2024-12-07"), "#626262", 2),
                new GroceryList(6, "Weekend boodschappen", DateOnly.Parse("2024-11-30"), "#003300", 2),

                new GroceryList(7, "Boodschappen familieweekend", DateOnly.Parse("2024-12-14"), "#FF6A00", 3),
                new GroceryList(8, "Kerstboodschappen", DateOnly.Parse("2024-12-07"), "#626262", 3),
                new GroceryList(9, "Weekend boodschappen", DateOnly.Parse("2024-11-30"), "#003300", 3)
            ];
        }

        public List<GroceryList> GetAll()
        {
            return groceryLists;
        }

        public List<GroceryList> GetAllOnClientId(int clientId)
        {
            return groceryLists.Where(g => g.ClientId == clientId).ToList();
        }

        public GroceryList Add(GroceryList item)
        {
            groceryLists.Add(item);
            return item;
        }

        public GroceryList? Delete(GroceryList item)
        {
            groceryLists.Remove(item);
            return item;
        }

        public GroceryList? Get(int id)
        {
            GroceryList? groceryList = groceryLists.FirstOrDefault(g => g.Id == id);
            return groceryList;
        }

        public GroceryList? Update(GroceryList item)
        {
            GroceryList? groceryList = groceryLists.FirstOrDefault(g => g.Id == item.Id);
            groceryList = item;
            return groceryList;
        }
    }
}