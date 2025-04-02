using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class VaccineCenterRepository : IVaccineCenterRepository
    {
        public void AddVaccineCenter(VaccineCenter center) => VaccineCenterDAO.Instance.AddCenter(center);

        public VaccineCenter GetVaccineCenterById(int centerId) => VaccineCenterDAO.Instance.GetCenterById(centerId);

        public (List<VaccineCenter> Centers, int TotalCount) GetAllVaccineCenters(int pageNumber, int pageSize)
            => VaccineCenterDAO.Instance.GetAllCenters(pageNumber, pageSize);

        public List<VaccineCenter> GetActiveCenters() => VaccineCenterDAO.Instance.GetActiveCenters();

        public void UpdateVaccineCenter(int centerId, VaccineCenter center)
            => VaccineCenterDAO.Instance.UpdateCenter(centerId, center);

        public void DeleteVaccineCenter(int centerId) => VaccineCenterDAO.Instance.DeleteCenter(centerId);

        public List<VaccineCenter> GetCentersByLocation(string location)
            => VaccineCenterDAO.Instance.GetCentersByLocation(location);
     
    }
}