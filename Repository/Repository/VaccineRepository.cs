using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class VaccineRepository : IVaccineRepository
    {
        public void AddVaccine(Vaccine vaccine) => VaccineDAO.Instance.AddVaccine(vaccine);

        public Vaccine GetVaccineById(int vaccineId) => VaccineDAO.Instance.GetVaccineById(vaccineId);

        public List<Vaccine> GetAllVaccines() => VaccineDAO.Instance.GetAllVaccines();

        public List<Vaccine> GetVaccinesByCategory(int categoryId) => VaccineDAO.Instance.GetVaccinesByCategory(categoryId);

        /*        public List<Vaccine> GetActiveVaccines() => VaccineDAO.Instance.GetActiveVaccines();

                public void UpdateVaccine(int vaccineId, Vaccine vaccine) => VaccineDAO.Instance.UpdateVaccine(vaccineId, vaccine);

                public void DeleteVaccine(int vaccineId) => VaccineDAO.Instance.DeleteVaccine(vaccineId);

                public List<Vaccine> GetVaccinesByStatus(string status) => VaccineDAO.Instance.GetVaccinesByStatus(status);

                public List<Vaccine> GetVaccinesByAgeRange(int minAge, int maxAge) => VaccineDAO.Instance.GetVaccinesByAgeRange(minAge, maxAge);

                public List<Vaccine> GetVaccinesByDiseaseType(string diseaseType) => VaccineDAO.Instance.GetVaccinesByDiseaseType(diseaseType);*/

       public List<Vaccine> GetVaccinesByBatch(int batchId)=>VaccineDAO.Instance.GetVaccinesByBatch(batchId);
    }
}