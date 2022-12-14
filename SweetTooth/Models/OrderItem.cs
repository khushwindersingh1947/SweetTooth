using System.ComponentModel.DataAnnotations;

namespace SweetTooth.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, 9999)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        // 1 product can be in 1 OrderItem
        public Product? Product { get; set; }

    }
}
