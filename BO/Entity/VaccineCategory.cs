using System.ComponentModel.DataAnnotations;

namespace BO.Entity
{
    public class VaccineCategory
    {
        [Key]
        public int VaccineCategoryId { get; set; }
        public int? FKParentCategoryId { get; set; }
        public VaccineCategory ParentCategory { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
