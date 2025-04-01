using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class VaccinePackageDAO
    {
        private ApplicationDbContext _dbContext;
        private static VaccinePackageDAO instance;

        public VaccinePackageDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static VaccinePackageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccinePackageDAO();
                }
                return instance;
            }
        }

        public VaccinePackage GetVaccinePackageById(int packageId)
        {
            return _dbContext.VaccinePackages
                .SingleOrDefault(vp => vp.VaccinePackageId == packageId);
        }

        public void AddVaccinePackage(VaccinePackage package)
        {
            _dbContext.VaccinePackages.Add(package);
            _dbContext.SaveChanges();
        }

        public void UpdateVaccinePackage(int packageId, VaccinePackage package)
        {
            var existingPackage = GetVaccinePackageById(packageId);
            if (existingPackage != null)
            {
                existingPackage.PackageName = package.PackageName;
                existingPackage.PackageDescription = package.PackageDescription;
                existingPackage.PackageStatus = package.PackageStatus;

                _dbContext.VaccinePackages.Update(existingPackage);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVaccinePackage(int packageId)
        {
            var package = GetVaccinePackageById(packageId);
            if (package != null)
            {
                _dbContext.VaccinePackages.Remove(package);
                _dbContext.SaveChanges();
            }
        }

        public List<VaccinePackage> GetAllVaccinePackages()
        {
            return _dbContext.VaccinePackages
                .ToList();
        }

        public List<VaccinePackage> GetVaccinePackagesByStatus(int status)
        {
            return _dbContext.VaccinePackages
                .Where(vp => vp.PackageStatus == status)
                .ToList();
        }
    }
}