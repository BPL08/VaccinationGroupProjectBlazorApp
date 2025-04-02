using BO.Entity;

namespace Repository.Interface
{
    public interface IVaccinationScheduleRepository
    {
        void AddVaccinationSchedule(VaccinationSchedule schedule);
        VaccinationSchedule GetVaccinationScheduleById(Guid scheduleId);

        List<VaccinationSchedule> GetSchedulesByAccountId(Guid accountId);
        List<VaccinationSchedule> GetAllVaccinationSchedules();
        List<VaccinationSchedule> GetVaccinationSchedulesByProfile(Guid profileId);
        List<VaccinationSchedule> GetVaccinationSchedulesByCenter(int centerId);
        List<VaccinationSchedule> GetVaccinationSchedulesByDateRange(DateTime startDate, DateTime endDate);
        List<VaccinationSchedule> GetVaccinationSchedulesByStatus(int status);
        void UpdateVaccinationSchedule(Guid scheduleId, VaccinationSchedule schedule);
        void DeleteVaccinationSchedule(Guid scheduleId);
        List<VaccinationSchedule> GetVaccinationSchedulesByProfileName(string profileName); // New method
        List<VaccinationSchedule> GetVaccinationSchedulesByCenterName(string centerName); // New method
        OrderDetail GetOrderDetailByVaccinationScheduleId(Guid vaccinationScheduleId); // New met
        /* List<VaccinationSchedule> GetVaccinationSchedulesByOrderDetail(Guid orderDetailId);*/
    }
}