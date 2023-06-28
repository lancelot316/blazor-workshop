using System.Net.Http.Json;

namespace BlazingPizza.Client
{
    public class OrdersClient
    {
        private readonly HttpClient _httpClient;

        public OrdersClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderWithStatus>> GetOrders() =>
            await _httpClient.GetFromJsonAsync("orders", OrderContext.Default.ListOrderWithStatus);

        public async Task<OrderWithStatus> GetOrder(int orderId) => 
            await _httpClient.GetFromJsonAsync($"orders/{orderId}", OrderContext.Default.OrderWithStatus);

        public async Task<int> PlaceOrder(Order order)
        {
            var response = await _httpClient.PostAsJsonAsync("orders", order, OrderContext.Default.Order);
            response.EnsureSuccessStatusCode();
            var orderId = await response.Content.ReadFromJsonAsync<int>();

            return orderId;
        }
    }
}
