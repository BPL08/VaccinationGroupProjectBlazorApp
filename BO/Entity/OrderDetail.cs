using System.ComponentModel.DataAnnotations;

namespace BO.Entity
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }
        public Guid FKOrderId { get; set; }
        public Order Order { get; set; }

        public int? FKVaccineId { get; set; } 
        public Vaccine Vaccine { get; set; }

        public int? FKVaccinePackageId { get; set; }
        public VaccinePackage VaccinePackage { get; set; }

     
        public int TotalPrice { get; set; }
    }
}
