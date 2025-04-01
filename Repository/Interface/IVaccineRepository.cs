using BO.Entity;

namespace Repository.Interface
{
    public interface IVaccineRepository
    {
        void AddVaccine(Vaccine vaccine);
        Vaccine GetVaccineById(int vaccineId);
        List<Vaccine> GetAllVaccines();
        List<Vaccine> GetVaccinesByCategory(int categoryId);
 /*       List<Vaccine> GetActiveVaccines();
        void UpdateVaccine(int vaccineId, Vaccine vaccine);
        void DeleteVaccine(int vaccineId);
        List<Vaccine> GetVaccinesByStatus(string status);
        List<Vaccine> GetVaccinesByAgeRange(int minAge, int maxAge);
        List<Vaccine> GetVaccinesByDiseaseType(string diseaseType);*/
    }
}