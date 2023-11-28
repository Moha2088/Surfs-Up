using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SurfsWebShopLibrary.Shared.ShoppingCart.Models
{
    public class ShoppingCartCountModel
    {
        public int Count { get; private set; }

        public event Action? UpdateCart;

        public async Task OnUpdateCartAsync(HttpClient httpClient)
        {
            Count = await httpClient.GetFromJsonAsync<int>(
                "/api/shopping-cart/count"
            );
            UpdateCart?.Invoke();
        }
    }
}
