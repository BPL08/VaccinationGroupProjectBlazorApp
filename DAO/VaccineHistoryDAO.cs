using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class VaccineHistoryDAO
    {
        private ApplicationDbContext _dbContext;
        private static VaccineHistoryDAO instance;

        public VaccineHistoryDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static VaccineHistoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccineHistoryDAO();
                }
                return instance;
            }
        }

        public VaccineHistory GetVaccineHistoryById(Guid historyId)
        {
            return _dbContext.VaccineHistories
                .Include(vh => vh.Vaccine)
                .Include(vh => vh.Profile)
                .Include(vh => vh.Center)
                .SingleOrDefault(vh => vh.VacineHistoryId == historyId);
        }

        public void AddVaccineHistory(VaccineHistory history)
        {
            _dbContext.VaccineHistories.Add(history);
            _dbContext.SaveChanges();
        }

        public void UpdateVaccineHistory(Guid historyId, VaccineHistory history)
        {
            var existingHistory = GetVaccineHistoryById(historyId);
            if (existingHistory != null)
            {
                existingHistory.FKVaccineId = history.FKVaccineId;
                existingHistory.FKProfileId = history.FKProfileId;
                existingHistory.AdministeredBy = history.AdministeredBy;
                existingHistory.FKCenterId = history.FKCenterId;
                existingHistory.AdministeredDate = history.AdministeredDate;
                existingHistory.DosedNumber = history.DosedNumber;
                existingHistory.Notes = history.Notes;
                existingHistory.VerifiedStatus = history.VerifiedStatus;

                _dbContext.VaccineHistories.Update(existingHistory);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVaccineHistory(Guid historyId)
        {
            var history = GetVaccineHistoryById(historyId);
            if (history != null)
            {
                _dbContext.VaccineHistories.Remove(history);
                _dbContext.SaveChanges();
            }
        }

        public List<VaccineHistory> GetAllVaccineHistories()
        {
            return _dbContext.VaccineHistories
                .Include(vh => vh.Vaccine)
                .Include(vh => vh.Profile)
                .Include(vh => vh.Center)
                .ToList();
        }

        public List<VaccineHistory> GetVaccineHistoriesByProfile(Guid profileId)
        {
            return _dbContext.VaccineHistories
                .Include(vh => vh.Vaccine)
                .Include(vh => vh.Profile)
                .Include(vh => vh.Center)
                .Where(vh => vh.FKProfileId == profileId)
                .ToList();
        }

        public List<VaccineHistory> GetVaccineHistoriesByVaccine(int vaccineId)
        {
            return _dbContext.VaccineHistories
                .Include(vh => vh.Vaccine)
                .Include(vh => vh.Profile)
                .Include(vh => vh.Center)
                .Where(vh => vh.FKVaccineId == vaccineId)
                .ToList();
        }

        public List<VaccineHistory> GetVaccineHistoriesByCenter(int centerId)
        {
            return _dbContext.VaccineHistories
                .Include(vh => vh.Vaccine)
                .Include(vh => vh.Profile)
                .Include(vh => vh.Center)
                .Where(vh => vh.FKCenterId == centerId)
                .ToList();
        }

        public List<VaccineHistory> GetVaccineHistoriesByVerificationStatus(int status)
        {
            return _dbContext.VaccineHistories
                .Include(vh => vh.Vaccine)
                .Include(vh => vh.Profile)
                .Include(vh => vh.Center)
                .Where(vh => vh.VerifiedStatus == status)
                .ToList();
        }

        public List<VaccineHistory> GetVaccineHistoriesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dbContext.VaccineHistories
                .Include(vh => vh.Vaccine)
                .Include(vh => vh.Profile)
                .Include(vh => vh.Center)
                .Where(vh => vh.AdministeredDate >= startDate && vh.AdministeredDate <= endDate)
                .ToList();
        }
    }
}