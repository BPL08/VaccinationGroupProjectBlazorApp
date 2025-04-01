using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class VaccineHistoryRepository : IVaccineHistoryRepository
    {
        public void AddVaccineHistory(VaccineHistory history) => VaccineHistoryDAO.Instance.AddVaccineHistory(history);

        public VaccineHistory GetVaccineHistoryById(Guid historyId) => VaccineHistoryDAO.Instance.GetVaccineHistoryById(historyId);

        public List<VaccineHistory> GetAllVaccineHistories() => VaccineHistoryDAO.Instance.GetAllVaccineHistories();

        public List<VaccineHistory> GetVaccineHistoriesByProfile(Guid profileId) => VaccineHistoryDAO.Instance.GetVaccineHistoriesByProfile(profileId);

        public List<VaccineHistory> GetVaccineHistoriesByVaccine(int vaccineId) => VaccineHistoryDAO.Instance.GetVaccineHistoriesByVaccine(vaccineId);

        public List<VaccineHistory> GetVaccineHistoriesByCenter(int centerId) => VaccineHistoryDAO.Instance.GetVaccineHistoriesByCenter(centerId);

        public List<VaccineHistory> GetVaccineHistoriesByDateRange(DateTime startDate, DateTime endDate) => VaccineHistoryDAO.Instance.GetVaccineHistoriesByDateRange(startDate, endDate);

        public List<VaccineHistory> GetVaccineHistoriesByVerificationStatus(int status) => VaccineHistoryDAO.Instance.GetVaccineHistoriesByVerificationStatus(status);

        public void UpdateVaccineHistory(Guid historyId, VaccineHistory history) => VaccineHistoryDAO.Instance.UpdateVaccineHistory(historyId, history);

        public void DeleteVaccineHistory(Guid historyId) => VaccineHistoryDAO.Instance.DeleteVaccineHistory(historyId);

        public List<VaccineHistory> GetVaccineHistoriesByAdministrator(string administratorId) => VaccineHistoryDAO.Instance.GetVaccineHistoriesByAdministrator(administratorId);
    }
}