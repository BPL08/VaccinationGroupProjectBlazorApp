using BO.Entity;

namespace Repository.Interface
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Order GetOrderById(Guid orderId);
        List<Order> GetAllOrders();
        List<Order> GetOrdersByAccount(string accountId);
        List<Order> GetOrdersByStatus(int status);
        List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
        void UpdateOrder(Guid orderId, Order order);
        void DeleteOrder(Guid orderId);
        List<Order> GetOrdersByPaymentMethod(string paymentMethod);
        decimal GetTotalOrderAmount(Guid orderId);
    }
}