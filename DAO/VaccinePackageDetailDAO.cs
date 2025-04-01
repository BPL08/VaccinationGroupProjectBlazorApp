using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class VaccinePackageDetailDAO
    {
        private ApplicationDbContext _dbContext;
        private static VaccinePackageDetailDAO instance;

        public VaccinePackageDetailDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static VaccinePackageDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccinePackageDetailDAO();
                }
                return instance;
            }
        }

        public VaccinePackageDetail GetVaccinePackageDetailById(Guid detailId)
        {
            return _dbContext.VaccinePackageDetails
                .Include(vpd => vpd.Vaccine)
                .Include(vpd => vpd.VaccinePackage)
                .SingleOrDefault(vpd => vpd.VaccinePackageDetailId == detailId);
        }

        public void AddVaccinePackageDetail(VaccinePackageDetail detail)
        {
            _dbContext.VaccinePackageDetails.Add(detail);
            _dbContext.SaveChanges();
        }

        public void UpdateVaccinePackageDetail(Guid detailId, VaccinePackageDetail detail)
        {
            var existingDetail = GetVaccinePackageDetailById(detailId);
            if (existingDetail != null)
            {
                existingDetail.FKVaccineId = detail.FKVaccineId;
                existingDetail.FKVaccinePackageId = detail.FKVaccinePackageId;
                existingDetail.PackagePrice = detail.PackagePrice;

                _dbContext.VaccinePackageDetails.Update(existingDetail);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVaccinePackageDetail(Guid detailId)
        {
            var detail = GetVaccinePackageDetailById(detailId);
            if (detail != null)
            {
                _dbContext.VaccinePackageDetails.Remove(detail);
                _dbContext.SaveChanges();
            }
        }

        public List<VaccinePackageDetail> GetAllVaccinePackageDetails()
        {
            return _dbContext.VaccinePackageDetails
                .Include(vpd => vpd.Vaccine)
                .Include(vpd => vpd.VaccinePackage)
                .ToList();
        }

        public List<VaccinePackageDetail> GetVaccinePackageDetailsByPackage(int packageId)
        {
            return _dbContext.VaccinePackageDetails
                .Include(vpd => vpd.Vaccine)
                .Include(vpd => vpd.VaccinePackage)
                .Where(vpd => vpd.FKVaccinePackageId == packageId)
                .ToList();
        }

        public List<VaccinePackageDetail> GetVaccinePackageDetailsByVaccine(int vaccineId)
        {
            return _dbContext.VaccinePackageDetails
                .Include(vpd => vpd.Vaccine)
                .Include(vpd => vpd.VaccinePackage)
                .Where(vpd => vpd.FKVaccineId == vaccineId)
                .ToList();
        }
    }
}