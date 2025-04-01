using BO.Entity;
using DAO;

namespace Repository.Repository
{
    public class VaccineCenterRepository : IVaccineCenterRepository
    {
        public void AddVaccineCenter(VaccineCenter center) => VaccineCenterDAO.Instance.AddVaccineCenter(center);

        public VaccineCenter GetVaccineCenterById(int centerId) => VaccineCenterDAO.Instance.GetVaccineCenterById(centerId);

        public List<VaccineCenter> GetAllVaccineCenters() => VaccineCenterDAO.Instance.GetAllVaccineCenters();

        public List<VaccineCenter> GetActiveCenters() => VaccineCenterDAO.Instance.GetActiveCenters();

        public void UpdateVaccineCenter(int centerId, VaccineCenter center) => VaccineCenterDAO.Instance.UpdateVaccineCenter(centerId, center);

        public void DeleteVaccineCenter(int centerId) => VaccineCenterDAO.Instance.DeleteVaccineCenter(centerId);

        public List<VaccineCenter> GetCentersByLocation(string location) => VaccineCenterDAO.Instance.GetCentersByLocation(location);

        public List<VaccineCenter> GetCentersByStatus(string status) => VaccineCenterDAO.Instance.GetCentersByStatus(status);
    }
}