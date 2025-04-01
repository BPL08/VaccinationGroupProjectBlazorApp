using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class VaccinePackageDetailRepository : IVaccinePackageDetailRepository
    {
        public void AddVaccinePackageDetail(VaccinePackageDetail detail) => VaccinePackageDetailDAO.Instance.AddVaccinePackageDetail(detail);

        public VaccinePackageDetail GetVaccinePackageDetailById(Guid detailId) => VaccinePackageDetailDAO.Instance.GetVaccinePackageDetailById(detailId);

        public List<VaccinePackageDetail> GetAllVaccinePackageDetails() => VaccinePackageDetailDAO.Instance.GetAllVaccinePackageDetails();

        public List<VaccinePackageDetail> GetVaccinePackageDetailsByPackage(int packageId) => VaccinePackageDetailDAO.Instance.GetVaccinePackageDetailsByPackage(packageId);

        public List<VaccinePackageDetail> GetVaccinePackageDetailsByVaccine(int vaccineId) => VaccinePackageDetailDAO.Instance.GetVaccinePackageDetailsByVaccine(vaccineId);

        public void UpdateVaccinePackageDetail(Guid detailId, VaccinePackageDetail detail) => VaccinePackageDetailDAO.Instance.UpdateVaccinePackageDetail(detailId, detail);

        public void DeleteVaccinePackageDetail(Guid detailId) => VaccinePackageDetailDAO.Instance.DeleteVaccinePackageDetail(detailId);
    }
}