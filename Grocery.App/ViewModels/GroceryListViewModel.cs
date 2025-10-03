using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class GroceryListViewModel : BaseViewModel
    {
        private readonly GlobalViewModel _global;
        public Client Client => _global.Client;
        public ObservableCollection<GroceryList> GroceryLists { get; set; }
        private readonly IGroceryListService _groceryListService;

        public GroceryListViewModel(IGroceryListService groceryListService, GlobalViewModel global)
        {
            Title = "Boodschappenlijst";
            _groceryListService = groceryListService;
            _global = global;
            GroceryLists = new(_groceryListService.GetAll().Where(g => g.ClientId == Client.Id));
        }

        [RelayCommand]
        public async Task ShowGroceryListItems(GroceryList groceryList)
        {
            var parameters = new Dictionary<string, object> { { "GroceryList", groceryList } };
            await Shell.Current.GoToAsync("GroceryListItemsView", parameters);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            GroceryLists = new(_groceryListService.GetAll().Where(g => g.ClientId == Client.Id));
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            GroceryLists.Clear();
        }

        [RelayCommand]
        public async Task ShowBoughtProducts()
        {
            if (Client != null && Client.Role == Role.Admin)
            {
                await Shell.Current.GoToAsync("BoughtProductsView");
            }
        }
    }
}