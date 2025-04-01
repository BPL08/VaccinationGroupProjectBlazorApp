using System.ComponentModel.DataAnnotations;

namespace BO.Entity
{
    public class VaccinationSchedule
    {
        [Key]
        public Guid VaccinationScheduleId { get; set; }
        public Guid FKProfileId { get; set; }
        public ChildrenProfile Profile { get; set; }
        public int FKCenterId { get; set; }
        public VaccineCenter Center { get; set; }
        public Guid FKOrderDetailsId { get; set; }
        public OrderDetail OrderDetail { get; set; }
     
        public int DoseNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string AdministeredBy { get; set; }
        public int Status { get; set; }
    }

}
