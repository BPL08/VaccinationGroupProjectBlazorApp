using BO.Entity;

namespace Repository.Interface
{
    public interface IVaccineBatchRepository
    {
        void AddVaccineBatch(VaccineBatch batch);
      /*  VaccineBatch GetVaccineBatchById(int batchId);
        List<VaccineBatch> GetAllVaccineBatches();
        List<VaccineBatch> GetVaccineBatchesByVaccine(int vaccineId);
        List<VaccineBatch> GetVaccineBatchesByCenter(int centerId);
        List<VaccineBatch> GetVaccineBatchesByExpirationDate(DateTime expirationDate);
        List<VaccineBatch> GetVaccineBatchesByStatus(string status);
        void UpdateVaccineBatch(int batchId, VaccineBatch batch);
        void DeleteVaccineBatch(int batchId);
        List<VaccineBatch> GetAvailableVaccineBatches();
        List<VaccineBatch> GetVaccineBatchesByManufacturer(string manufacturer);*/
    }
}