using System.ComponentModel.DataAnnotations;

namespace ShoesStoreAPI.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required]
        public double Total { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
    }
}
