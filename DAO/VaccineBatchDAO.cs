using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class VaccineBatchDAO
    {
        private ApplicationDbContext _dbContext;
        private static VaccineBatchDAO instance;

        public VaccineBatchDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static VaccineBatchDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccineBatchDAO();
                }
                return instance;
            }
        }

        public VaccineBatch GetVaccineBatchById(int batchId)
        {
            return _dbContext.VaccineBatches
                .Include(vb => vb.Center)
                .SingleOrDefault(vb => vb.VaccineBatchId == batchId);
        }

        public void AddVaccineBatch(VaccineBatch batch)
        {
            _dbContext.VaccineBatches.Add(batch);
            _dbContext.SaveChanges();
        }

        public void UpdateVaccineBatch(int batchId, VaccineBatch batch)
        {
            var existingBatch = GetVaccineBatchById(batchId);
            if (existingBatch != null)
            {
                existingBatch.FKCenterId = batch.FKCenterId;
                existingBatch.BatchNumber = batch.BatchNumber;
                existingBatch.ActiveStatus = batch.ActiveStatus;

                _dbContext.VaccineBatches.Update(existingBatch);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVaccineBatch(int batchId)
        {
            var batch = GetVaccineBatchById(batchId);
            if (batch != null)
            {
                _dbContext.VaccineBatches.Remove(batch);
                _dbContext.SaveChanges();
            }
        }

        public List<VaccineBatch> GetAllVaccineBatches()
        {
            return _dbContext.VaccineBatches
                .Include(vb => vb.Center)
                .ToList();
        }

        public List<VaccineBatch> GetVaccineBatchesByCenter(int centerId)
        {
            return _dbContext.VaccineBatches
                .Include(vb => vb.Center)
                .Where(vb => vb.FKCenterId == centerId)
                .ToList();
        }

        public List<VaccineBatch> GetVaccineBatchesByStatus(string status)
        {
            return _dbContext.VaccineBatches
                .Include(vb => vb.Center)
                .Where(vb => vb.ActiveStatus == status)
                .ToList();
        }
        public bool BatchNumberExists(string batchNumber)
        {
            return _dbContext.VaccineBatches
                .Any(vb => vb.BatchNumber.ToLower() == batchNumber.ToLower());
        }
    }
}