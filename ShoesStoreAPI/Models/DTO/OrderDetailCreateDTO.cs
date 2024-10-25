using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesStoreAPI.Models.DTO
{
    public class OrderDetailCreateDTO
    {
        public int OrderId { get; set; }
        public int ShoeId { get; set; }
        public int Quantity { get; set; }
    }
}
