using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddOrderDetail(orderDetail);

        public OrderDetail GetOrderDetailById(Guid orderDetailId) => OrderDetailDAO.Instance.GetOrderDetailById(orderDetailId);

        public List<OrderDetail> GetAllOrderDetails() => OrderDetailDAO.Instance.GetAllOrderDetails();

        public List<OrderDetail> GetOrderDetailsByOrder(Guid orderId) => OrderDetailDAO.Instance.GetOrderDetailsByOrder(orderId);

        public List<OrderDetail> GetOrderDetailsByVaccine(int vaccineId) => OrderDetailDAO.Instance.GetOrderDetailsByVaccine(vaccineId);

        public List<OrderDetail> GetOrderDetailsByVaccinePackage(int packageId) => OrderDetailDAO.Instance.GetOrderDetailsByVaccinePackage(packageId);

        public void UpdateOrderDetail(Guid orderDetailId, OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(orderDetailId, orderDetail);

        public void DeleteOrderDetail(Guid orderDetailId) => OrderDetailDAO.Instance.DeleteOrderDetail(orderDetailId);
    }
}