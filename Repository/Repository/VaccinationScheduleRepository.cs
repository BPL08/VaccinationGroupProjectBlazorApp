using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class VaccinationScheduleRepository : IVaccinationScheduleRepository
    {
        public void AddVaccinationSchedule(VaccinationSchedule schedule) => VaccinationScheduleDAO.Instance.AddSchedule(schedule);

        public VaccinationSchedule GetVaccinationScheduleById(Guid scheduleId) => VaccinationScheduleDAO.Instance.GetScheduleById(scheduleId);

        public List<VaccinationSchedule> GetAllVaccinationSchedules() => VaccinationScheduleDAO.Instance.GetAllSchedules();

        public List<VaccinationSchedule> GetVaccinationSchedulesByProfile(Guid profileId) => VaccinationScheduleDAO.Instance.GetSchedulesByProfile(profileId);

        public List<VaccinationSchedule> GetVaccinationSchedulesByCenter(int centerId) => VaccinationScheduleDAO.Instance.GetSchedulesByCenter(centerId);

        public List<VaccinationSchedule> GetVaccinationSchedulesByDateRange(DateTime startDate, DateTime endDate) => VaccinationScheduleDAO.Instance.GetSchedulesByDateRange(startDate, endDate);

        public List<VaccinationSchedule> GetVaccinationSchedulesByStatus(int status) => VaccinationScheduleDAO.Instance.GetSchedulesByStatus(status);

        public void UpdateVaccinationSchedule(Guid scheduleId, VaccinationSchedule schedule)
        {
            try
            {
                VaccinationScheduleDAO.Instance.UpdateSchedule(scheduleId, schedule);
                if (VaccinationScheduleDAO.Instance.AreAllSchedulesCompleted(scheduleId))
                {
                    var order = VaccinationScheduleDAO.Instance.FindOrderByVaccinationScheduleId(scheduleId);
                    if (order != null)
                    {
                        var orderId = order.OrderId;
                        int totalPaidPrice = OrderDAO.Instance.GetTotalPriceOfOrderDetails(orderId);
                        order.Status = 2; 
                        order.TotalPaidPrice = totalPaidPrice;
                        OrderDAO.Instance.UpdateOrder(orderId, order);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating vaccination schedule: {ex.Message}", ex);
            }
        }
        public void DeleteVaccinationSchedule(Guid scheduleId) => VaccinationScheduleDAO.Instance.DeleteSchedule(scheduleId);

        public List<VaccinationSchedule> GetSchedulesByAccountId(Guid accountId) => VaccinationScheduleDAO.Instance.GetSchedulesByAccountId(accountId);
        public List<VaccinationSchedule> GetVaccinationSchedulesByProfileName(string profileName) => VaccinationScheduleDAO.Instance.GetSchedulesByProfileName(profileName);

        public List<VaccinationSchedule> GetVaccinationSchedulesByCenterName(string centerName) => VaccinationScheduleDAO.Instance.GetSchedulesByCenterName(centerName);

        public OrderDetail GetOrderDetailByVaccinationScheduleId(Guid vaccinationScheduleId) => VaccinationScheduleDAO.Instance.GetOrderDetailByVaccinationScheduleId(vaccinationScheduleId);


        public bool AreAllSchedulesCompleted(Guid vaccinationScheduleId)
            => VaccinationScheduleDAO.Instance.AreAllSchedulesCompleted(vaccinationScheduleId);

       
        /*   public List<VaccinationSchedule> GetVaccinationSchedulesByOrderDetail(Guid orderDetailId) => VaccinationScheduleDAO.Instance.GetSchedulesByOrderDetail(orderDetailId);*/
    }
}