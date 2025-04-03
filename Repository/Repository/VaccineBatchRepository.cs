using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class VaccineBatchRepository : IVaccineBatchRepository
    {
        public void AddVaccineBatch(VaccineBatch batch) => VaccineBatchDAO.Instance.AddVaccineBatch(batch);

        public VaccineBatch GetVaccineBatchById(int batchId) => VaccineBatchDAO.Instance.GetVaccineBatchById(batchId);

        public List<VaccineBatch> GetAllVaccineBatches() => VaccineBatchDAO.Instance.GetAllVaccineBatches();

        public void UpdateVaccineBatch(int batchId, VaccineBatch batch) => VaccineBatchDAO.Instance.UpdateVaccineBatch(batchId, batch);
        public bool BatchNumberExists(string batchNumber)
        => VaccineBatchDAO.Instance.BatchNumberExists(batchNumber);

        /*     public List<VaccineBatch> GetVaccineBatchesByVaccine(int vaccineId) => VaccineBatchDAO.Instance.GetVaccineBatchesByVaccine(vaccineId);

             public List<VaccineBatch> GetActiveBatches() => VaccineBatchDAO.Instance.GetActiveBatches();

             public void UpdateVaccineBatch(int batchId, VaccineBatch batch) => VaccineBatchDAO.Instance.UpdateVaccineBatch(batchId, batch);

             public void DeleteVaccineBatch(int batchId) => VaccineBatchDAO.Instance.DeleteVaccineBatch(batchId);

             public List<VaccineBatch> GetBatchesByExpiryDate(DateTime expiryDate) => VaccineBatchDAO.Instance.GetBatchesByExpiryDate(expiryDate);

             public List<VaccineBatch> GetBatchesByManufacturer(string manufacturer) => VaccineBatchDAO.Instance.GetBatchesByManufacturer(manufacturer);*/

    }
}