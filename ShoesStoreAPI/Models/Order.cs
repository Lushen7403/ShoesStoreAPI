using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesStoreAPI.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
