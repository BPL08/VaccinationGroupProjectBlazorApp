using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class OrderDAO
    {
        private ApplicationDbContext _dbContext;
        private static OrderDAO instance;

        public OrderDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public Order GetOrderById(Guid orderId)
        {
            return _dbContext.Orders
                .Include(o => o.Profile)
                .SingleOrDefault(o => o.OrderId == orderId);
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Guid orderId, Order order)
        {
            var existingOrder = GetOrderById(orderId);
            if (existingOrder != null)
            {
                existingOrder.FKProfileId = order.FKProfileId;
                existingOrder.TotalAmountPrice = order.TotalAmountPrice;
                existingOrder.TotalPaidPrice = order.TotalPaidPrice;
                existingOrder.PurchaseDate = order.PurchaseDate;
                existingOrder.Status = order.Status;

                _dbContext.Orders.Update(existingOrder);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteOrder(Guid orderId)
        {
            var order = GetOrderById(orderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()
        {
            return _dbContext.Orders
                .Include(o => o.Profile)
                .ToList();
        }

        public List<Order> GetOrdersByStatus(int status)
        {
            return _dbContext.Orders
                .Include(o => o.Profile)
                .Where(o => o.Status == status)
                .ToList();
        }

        public List<Order> GetOrdersByProfile(Guid profileId)
        {
            return _dbContext.Orders
                .Include(o => o.Profile)
                .Where(o => o.FKProfileId == profileId)
                .ToList();
        }

        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Orders
                .Include(o => o.Profile)
                .Where(o => o.PurchaseDate >= startDate && o.PurchaseDate <= endDate)
                .ToList();
        }
    }
}