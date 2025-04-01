using System.ComponentModel.DataAnnotations;

namespace BO.Entity
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
       
     
        public Guid FKProfileId { get; set; }
        public ChildrenProfile Profile { get; set; }
        public int TotalAmountPrice { get; set; }
        public int TotalPaidPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Status { get; set; }
    }
}
