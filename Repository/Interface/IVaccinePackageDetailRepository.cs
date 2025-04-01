using BO.Entity;

namespace Repository.Interface
{
    public interface IVaccinePackageDetailRepository
    {
        void AddVaccinePackageDetail(VaccinePackageDetail detail);
        VaccinePackageDetail GetVaccinePackageDetailById(Guid detailId);
        List<VaccinePackageDetail> GetAllVaccinePackageDetails();
        List<VaccinePackageDetail> GetVaccinePackageDetailsByPackage(int packageId);
        List<VaccinePackageDetail> GetVaccinePackageDetailsByVaccine(int vaccineId);
        void UpdateVaccinePackageDetail(Guid detailId, VaccinePackageDetail detail);
        void DeleteVaccinePackageDetail(Guid detailId);
    }
}