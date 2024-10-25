using System.ComponentModel.DataAnnotations;

namespace ShoesStoreAPI.Models.DTO
{
    public class OrderCreateDTO
    {
        [Required]
        public double Total { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
    }
}
