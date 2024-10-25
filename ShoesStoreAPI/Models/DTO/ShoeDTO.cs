using System.ComponentModel.DataAnnotations;

namespace ShoesStoreAPI.Models.DTO
{
    public class ShoeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
