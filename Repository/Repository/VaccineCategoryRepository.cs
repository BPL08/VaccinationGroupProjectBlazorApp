using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class VaccineCategoryRepository : IVaccineCategoryRepository
    {
        public void AddVaccineCategory(VaccineCategory category) => VaccineCategoryDAO.Instance.AddVaccineCategory(category);

        public VaccineCategory GetVaccineCategoryById(int categoryId) => VaccineCategoryDAO.Instance.GetVaccineCategoryById(categoryId);

        public List<VaccineCategory> GetAllVaccineCategories() => VaccineCategoryDAO.Instance.GetAllVaccineCategories();

        public void UpdateVaccineCategory(int categoryId, VaccineCategory category) 
            => VaccineCategoryDAO.Instance.UpdateVaccineCategory(categoryId, category);

        public void DeleteVaccineCategory(int categoryId) 
            => VaccineCategoryDAO.Instance.DeleteVaccineCategory(categoryId);

        public List<VaccineCategory> GetCategoriesByStatus(string status) 
            => VaccineCategoryDAO.Instance.GetCategoriesByStatus(status);
    }
}