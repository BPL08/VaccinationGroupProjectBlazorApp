using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class VaccineCenterDAO
    {
        private ApplicationDbContext _dbContext;
        private static VaccineCenterDAO instance;

        public VaccineCenterDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static VaccineCenterDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccineCenterDAO();
                }
                return instance;
            }
        }

        public VaccineCenter GetCenterById(int centerId)
        {
            return _dbContext.VaccineCenters
                .SingleOrDefault(vc => vc.VacineCenterId == centerId);
        }

        public void AddCenter(VaccineCenter center)
        {
            _dbContext.VaccineCenters.Add(center);
            _dbContext.SaveChanges();
        }

        public void UpdateCenter(int centerId, VaccineCenter center)
        {
            var existingCenter = GetCenterById(centerId);
            if (existingCenter != null)
            {
                existingCenter.Name = center.Name;
                existingCenter.Location = center.Location;
                existingCenter.ContactNumber = center.ContactNumber;
                existingCenter.Email = center.Email;
                existingCenter.Status = center.Status;

                _dbContext.VaccineCenters.Update(existingCenter);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCenter(int centerId)
        {
            var center = GetCenterById(centerId);
            if (center != null)
            {
                _dbContext.VaccineCenters.Remove(center);
                _dbContext.SaveChanges();
            }
        }

        public (List<VaccineCenter> Centers, int TotalCount) GetAllCenters(int pageNumber, int pageSize)
        {
            var query = _dbContext.VaccineCenters.AsQueryable();
            int totalCount = query.Count();

            var centers = query

                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (centers, totalCount);
        }
        public List<VaccineCenter> GetAllCenters()
        {
            return _dbContext.VaccineCenters.ToList();
        }


        public List<VaccineCenter> GetActiveCenters()
        {
            return _dbContext.VaccineCenters
                .Where(vc => vc.Status == "Active")
                .ToList();
        }

        public List<VaccineCenter> GetCentersByLocation(string location)
        {
            return _dbContext.VaccineCenters
                .Where(vc => vc.Location.Contains(location))
                .ToList();
        }
    }
}