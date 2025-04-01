using System.ComponentModel.DataAnnotations;

namespace BO.Entity
{
    public class VaccineBatch
    {
        [Key]
        public int VaccineBatchId { get; set; }
 
        public int FKCenterId { get; set; }
        public VaccineCenter Center { get; set; }
        public string BatchNumber { get; set; }
        public string ActiveStatus { get; set; }
       
    }

}
