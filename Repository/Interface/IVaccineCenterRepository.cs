using BO.Entity;

namespace Repository.Interface
{
    public interface IVaccineCenterRepository
    {
        void AddVaccineCenter(VaccineCenter center);
        /*  VaccineCenter GetVaccineCenterById(int centerId);
          List<VaccineCenter> GetAllVaccineCenters();
          List<VaccineCenter> GetVaccineCentersByCity(string city);
          List<VaccineCenter> GetVaccineCentersByDistrict(string district);
          List<VaccineCenter> GetActiveCenters();
          void UpdateVaccineCenter(int centerId, VaccineCenter center);
          void DeleteVaccineCenter(int centerId);
          List<VaccineCenter> GetCentersByStatus(string status);
          List<VaccineCenter> GetCentersByOperatingHours(string dayOfWeek);*/
        (List<VaccineCenter> Centers, int TotalCount) GetAllVaccineCenters(int pageNumber, int pageSize);
    }
}