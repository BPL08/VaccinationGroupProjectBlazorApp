using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class VaccineDAO
    {
        private ApplicationDbContext _dbContext;
        private static VaccineDAO instance;

        public VaccineDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static VaccineDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccineDAO();
                }
                return instance;
            }
        }

        public Vaccine GetVaccineById(int vaccineId)
        {
            return _dbContext.Vaccines
                .Include(v => v.Category)
                .Include(v => v.Batch)
                .SingleOrDefault(v => v.VaccineId == vaccineId);
        }

        public void AddVaccine(Vaccine vaccine)
        {
            _dbContext.Vaccines.Add(vaccine);
            _dbContext.SaveChanges();
        }

        public void UpdateVaccine(int vaccineId, Vaccine vaccine)
        {
            var existingVaccine = GetVaccineById(vaccineId);
            if (existingVaccine != null)
            {
                existingVaccine.Name = vaccine.Name;
                existingVaccine.UnitOfVolume = vaccine.UnitOfVolume;
                existingVaccine.IngredientsDescription = vaccine.IngredientsDescription;
                existingVaccine.MinAge = vaccine.MinAge;
                existingVaccine.MaxAge = vaccine.MaxAge;
                existingVaccine.BetweenPeriod = vaccine.BetweenPeriod;
                existingVaccine.Price = vaccine.Price;
                existingVaccine.ProductionDate = vaccine.ProductionDate;
                existingVaccine.ExpirationDate = vaccine.ExpirationDate;
                existingVaccine.FKCategoryId = vaccine.FKCategoryId;
                existingVaccine.FKBatchId = vaccine.FKBatchId;
                existingVaccine.Status = vaccine.Status;
                _dbContext.Vaccines.Update(existingVaccine);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVaccine(int vaccineId)
        {
            var vaccine = GetVaccineById(vaccineId);
            if (vaccine != null)
            {
                _dbContext.Vaccines.Remove(vaccine);
                _dbContext.SaveChanges();
            }
        }

        public List<Vaccine> GetAllVaccines()
        {
            return _dbContext.Vaccines
                .Include(v => v.Category)
                .Include(v => v.Batch)
                .ToList();
        }

        public List<Vaccine> GetVaccinesByCategory(int categoryId)
        {
            return _dbContext.Vaccines
                .Include(v => v.Category)
                .Include(v => v.Batch)
                .Where(v => v.FKCategoryId == categoryId)
                .ToList();
        }

        public List<Vaccine> GetVaccinesByBatch(int batchId)
        {
            return _dbContext.Vaccines
                .Include(v => v.Category)
                .Include(v => v.Batch)
                .Where(v => v.FKBatchId == batchId)
                .ToList();
        }

        public List<Vaccine> GetVaccinesByAgeRange(int age)
        {
            return _dbContext.Vaccines
                .Include(v => v.Category)
                .Include(v => v.Batch)
                .Where(v => v.MinAge <= age && v.MaxAge >= age)
                .ToList();
        }
    }
}