using BO.Entity;

namespace Repository.Interface
{
    public interface IVaccineHistoryRepository
    {
        void AddVaccineHistory(VaccineHistory history);
        VaccineHistory GetVaccineHistoryById(Guid historyId);
        List<VaccineHistory> GetAllVaccineHistories();
        List<VaccineHistory> GetVaccineHistoriesByProfile(Guid profileId);
        List<VaccineHistory> GetVaccineHistoriesByVaccine(int vaccineId);
        List<VaccineHistory> GetVaccineHistoriesByCenter(int centerId);
        List<VaccineHistory> GetVaccineHistoriesByDateRange(DateTime startDate, DateTime endDate);
        List<VaccineHistory> GetVaccineHistoriesByVerificationStatus(int status);
        void UpdateVaccineHistory(Guid historyId, VaccineHistory history);
        void DeleteVaccineHistory(Guid historyId);
      /*  List<VaccineHistory> GetVaccineHistoriesByAdministrator(string administratorId);*/
    }
}