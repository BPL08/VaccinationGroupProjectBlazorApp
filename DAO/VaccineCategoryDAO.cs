using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class VaccineCategoryDAO
    {
        private ApplicationDbContext _dbContext;
        private static VaccineCategoryDAO instance;

        public VaccineCategoryDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static VaccineCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccineCategoryDAO();
                }
                return instance;
            }
        }

        public VaccineCategory GetVaccineCategoryById(int categoryId)
        {
            return _dbContext.VaccineCategories
                .Include(vc => vc.ParentCategory)
                .SingleOrDefault(vc => vc.VaccineCategoryId == categoryId);
        }

        public void AddVaccineCategory(VaccineCategory category)
        {
            _dbContext.VaccineCategories.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateVaccineCategory(int categoryId, VaccineCategory category)
        {
            var existingCategory = GetVaccineCategoryById(categoryId);
            if (existingCategory != null)
            {
                existingCategory.FKParentCategoryId = category.FKParentCategoryId;
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.Description = category.Description;
                existingCategory.Status = category.Status;

                _dbContext.VaccineCategories.Update(existingCategory);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVaccineCategory(int categoryId)
        {
            var category = GetVaccineCategoryById(categoryId);
            if (category != null)
            {
                _dbContext.VaccineCategories.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public List<VaccineCategory> GetAllVaccineCategories()
        {
            return _dbContext.VaccineCategories
                .Include(vc => vc.ParentCategory)
                .ToList();
        }

        public List<VaccineCategory> GetSubCategories(int parentCategoryId)
        {
            return _dbContext.VaccineCategories
                .Include(vc => vc.ParentCategory)
                .Where(vc => vc.FKParentCategoryId == parentCategoryId)
                .ToList();
        }

        public List<VaccineCategory> GetRootCategories()
        {
            return _dbContext.VaccineCategories
                .Include(vc => vc.ParentCategory)
                .Where(vc => vc.FKParentCategoryId == null)
                .ToList();
        }

        public List<VaccineCategory> GetCategoriesByStatus(string status)
        {
            return _dbContext.VaccineCategories
                .Include(vc => vc.ParentCategory)
                .Where(vc => vc.Status == status)
                .ToList();
        }
    }
}