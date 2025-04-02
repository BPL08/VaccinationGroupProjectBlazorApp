using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order order) => OrderDAO.Instance.AddOrder(order);

        public List<Order> GetOrdersByAccountId(Guid accountId) => OrderDAO.Instance.GetOrdersByAccountId(accountId);
        public Order GetOrderById(Guid orderId) => OrderDAO.Instance.GetOrderById(orderId);

        public List<Order> GetAllOrders() => OrderDAO.Instance.GetAllOrders();

      /*  public List<Order> GetOrdersByAccount(string accountId) => OrderDAO.Instance.GetOrdersByAccount(accountId);*/

        public List<Order> GetOrdersByStatus(int status) => OrderDAO.Instance.GetOrdersByStatus(status);

        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate) => OrderDAO.Instance.GetOrdersByDateRange(startDate, endDate);

        public void UpdateOrder(Guid orderId, Order order) => OrderDAO.Instance.UpdateOrder(orderId, order);

        public void DeleteOrder(Guid orderId) => OrderDAO.Instance.DeleteOrder(orderId);

/*        public List<Order> GetOrdersByPaymentMethod(string paymentMethod) => OrderDAO.Instance.GetOrdersByPaymentMethod(paymentMethod);

        public decimal GetTotalOrderAmount(Guid orderId) => OrderDAO.Instance.GetTotalOrderAmount(orderId);*/
    }
}