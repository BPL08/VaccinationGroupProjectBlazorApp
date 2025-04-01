using BO.Entity;

namespace Repository.Interface
{
    public interface IOrderDetailRepository
    {
        void AddOrderDetail(OrderDetail orderDetail);
        OrderDetail GetOrderDetailById(Guid orderDetailId);
        List<OrderDetail> GetAllOrderDetails();
        List<OrderDetail> GetOrderDetailsByOrder(Guid orderId);
        List<OrderDetail> GetOrderDetailsByVaccine(int vaccineId);
        List<OrderDetail> GetOrderDetailsByVaccinePackage(int packageId);
        void UpdateOrderDetail(Guid orderDetailId, OrderDetail orderDetail);
        void DeleteOrderDetail(Guid orderDetailId);
      /*  decimal GetTotalPrice(Guid orderDetailId);*/
    }
}