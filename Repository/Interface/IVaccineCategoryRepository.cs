using BO.Entity;

namespace Repository.Interface
{
    public interface IVaccineCategoryRepository
    {
        void AddVaccineCategory(VaccineCategory category);
        VaccineCategory GetVaccineCategoryById(int categoryId);
        List<VaccineCategory> GetAllVaccineCategories();
        void UpdateVaccineCategory(int categoryId, VaccineCategory category);
        void DeleteVaccineCategory(int categoryId);
        List<VaccineCategory> GetCategoriesByStatus(string status);
    }
}