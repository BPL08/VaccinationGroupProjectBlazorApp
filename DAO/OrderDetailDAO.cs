using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class OrderDetailDAO
    {
        private ApplicationDbContext _dbContext;
        private static OrderDetailDAO instance;

        public OrderDetailDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }

        public OrderDetail GetOrderDetailById(Guid orderDetailId)
        {
            return _dbContext.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Vaccine)
                .Include(od => od.VaccinePackage)
                .SingleOrDefault(od => od.OrderDetailId == orderDetailId);
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Add(orderDetail);
            _dbContext.SaveChanges();
        }

        public void UpdateOrderDetail(Guid orderDetailId, OrderDetail orderDetail)
        {
            var existingOrderDetail = GetOrderDetailById(orderDetailId);
            if (existingOrderDetail != null)
            {
                existingOrderDetail.FKOrderId = orderDetail.FKOrderId;
                existingOrderDetail.FKVaccineId = orderDetail.FKVaccineId;
                existingOrderDetail.FKVaccinePackageId = orderDetail.FKVaccinePackageId;
                existingOrderDetail.TotalPrice = orderDetail.TotalPrice;

                _dbContext.OrderDetails.Update(existingOrderDetail);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteOrderDetail(Guid orderDetailId)
        {
            var orderDetail = GetOrderDetailById(orderDetailId);
            if (orderDetail != null)
            {
                _dbContext.OrderDetails.Remove(orderDetail);
                _dbContext.SaveChanges();
            }
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _dbContext.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Vaccine)
                .Include(od => od.VaccinePackage)
                .ToList();
        }

        public List<OrderDetail> GetOrderDetailsByOrder(Guid orderId)
        {
            return _dbContext.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Vaccine)
                .Include(od => od.VaccinePackage)
                .Where(od => od.FKOrderId == orderId)
                .ToList();
        }

        public List<OrderDetail> GetOrderDetailsByVaccine(int vaccineId)
        {
            return _dbContext.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Vaccine)
                .Include(od => od.VaccinePackage)
                .Where(od => od.FKVaccineId == vaccineId)
                .ToList();
        }

        public List<OrderDetail> GetOrderDetailsByVaccinePackage(int packageId)
        {
            return _dbContext.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Vaccine)
                .Include(od => od.VaccinePackage)
                .Where(od => od.FKVaccinePackageId == packageId)
                .ToList();
        }
    }
}