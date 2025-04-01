using BO.Entity;
using DAO;

namespace Repository.Repository
{
    public class VaccineCategoryRepository : IVaccineCategoryRepository
    {
        public void AddVaccineCategory(VaccineCategory category) => VaccineCategoryDAO.Instance.AddVaccineCategory(category);

        public VaccineCategory GetVaccineCategoryById(int categoryId) => VaccineCategoryDAO.Instance.GetVaccineCategoryById(categoryId);

        public List<VaccineCategory> GetAllVaccineCategories() => VaccineCategoryDAO.Instance.GetAllVaccineCategories();

        public List<VaccineCategory> GetActiveCategories() => VaccineCategoryDAO.Instance.GetActiveCategories();

        public void UpdateVaccineCategory(int categoryId, VaccineCategory category) => VaccineCategoryDAO.Instance.UpdateVaccineCategory(categoryId, category);

        public void DeleteVaccineCategory(int categoryId) => VaccineCategoryDAO.Instance.DeleteVaccineCategory(categoryId);

        public List<VaccineCategory> GetCategoriesByDiseaseType(string diseaseType) => VaccineCategoryDAO.Instance.GetCategoriesByDiseaseType(diseaseType);
    }
}