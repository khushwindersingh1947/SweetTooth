using System.ComponentModel.DataAnnotations;

namespace SweetTooth.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 0.01, maximum: 999)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        public string? Image { get; set; } //the ? means it can be null
    }
}
