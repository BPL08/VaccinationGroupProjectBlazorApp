using BO.Entity;

namespace Repository.Interface
{
    public interface IVaccinePackageRepository
    {
        void AddVaccinePackage(VaccinePackage package);
        VaccinePackage GetVaccinePackageById(int packageId);
        List<VaccinePackage> GetAllVaccinePackages();
  /*      List<VaccinePackage> GetActivePackages();
        List<VaccinePackage> GetPackagesByAgeGroup(string ageGroup);
        List<VaccinePackage> GetPackagesByPriceRange(decimal minPrice, decimal maxPrice);
        void UpdateVaccinePackage(int packageId, VaccinePackage package);
        void DeleteVaccinePackage(int packageId);
        List<VaccinePackage> GetPackagesByStatus(string status);
        List<VaccinePackage> GetPackagesByVaccine(int vaccineId);*/
    }
}