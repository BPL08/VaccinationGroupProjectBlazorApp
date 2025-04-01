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

        public void UpdateVaccinationSchedule(Guid scheduleId, VaccinationSchedule schedule) => VaccinationScheduleDAO.Instance.UpdateSchedule(scheduleId, schedule);

        public void DeleteVaccinationSchedule(Guid scheduleId) => VaccinationScheduleDAO.Instance.DeleteSchedule(scheduleId);

     /*   public List<VaccinationSchedule> GetVaccinationSchedulesByOrderDetail(Guid orderDetailId) => VaccinationScheduleDAO.Instance.GetSchedulesByOrderDetail(orderDetailId);*/
    }
}