using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesStoreAPI.Models
{
    [PrimaryKey(nameof(OrderId), nameof(ShoeId))]
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ShoeId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ShoeId")]
        public Shoe Shoe { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
