using BO.Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Interface
{
    public interface IVaccineCenterRepository
    {
        void AddVaccineCenter(VaccineCenter center);
        VaccineCenter GetVaccineCenterById(int centerId);
        public List<VaccineCenter> GetAllVaccineCenters();
        void UpdateVaccineCenter(int centerId, VaccineCenter center);
        void DeleteVaccineCenter(int centerId);
        (List<VaccineCenter> Centers, int TotalCount) GetAllVaccineCenters(int pageNumber, int pageSize);
        List<VaccineCenter> SearchCenters(string searchTerm);
    }
}