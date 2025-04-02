using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class VaccinePackageRepository : IVaccinePackageRepository
    {
        public void AddVaccinePackage(VaccinePackage package) => VaccinePackageDAO.Instance.AddVaccinePackage(package);

        public VaccinePackage GetVaccinePackageById(int packageId) => VaccinePackageDAO.Instance.GetVaccinePackageById(packageId);

        public List<VaccinePackage> GetAllVaccinePackages() => VaccinePackageDAO.Instance.GetAllVaccinePackages();
        public void UpdateVaccinePackage(int packageId, VaccinePackage package) => VaccinePackageDAO.Instance.UpdateVaccinePackage(packageId, package);

        /*    public List<VaccinePackage> GetActivePackages() => VaccinePackageDAO.Instance.GetActivePackages();

            public List<VaccinePackage> GetPackagesByAgeGroup(string ageGroup) => VaccinePackageDAO.Instance.GetPackagesByAgeGroup(ageGroup);

            public List<VaccinePackage> GetPackagesByPriceRange(decimal minPrice, decimal maxPrice) => VaccinePackageDAO.Instance.GetPackagesByPriceRange(minPrice, maxPrice);

            public void UpdateVaccinePackage(int packageId, VaccinePackage package) => VaccinePackageDAO.Instance.UpdateVaccinePackage(packageId, package);

            public void DeleteVaccinePackage(int packageId) => VaccinePackageDAO.Instance.DeleteVaccinePackage(packageId);

            public List<VaccinePackage> GetPackagesByStatus(string status) => VaccinePackageDAO.Instance.GetPackagesByStatus(status);

            public List<VaccinePackage> GetPackagesByVaccine(int vaccineId) => VaccinePackageDAO.Instance.GetPackagesByVaccine(vaccineId);*/
    }
}