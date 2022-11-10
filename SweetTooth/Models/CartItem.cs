using System.ComponentModel.DataAnnotations;

namespace SweetTooth.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        [Required]
        [Range(1,100)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01,9999)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        public int ProductId { get; set; } 

        public string UserId { get; set; }

        //1 cart item contain 1 product
        public Product? Product { get; set; }
    }
}
