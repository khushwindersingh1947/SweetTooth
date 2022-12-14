using System.ComponentModel.DataAnnotations;

namespace SweetTooth.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        [DisplayFormat(DataFormatString = "{0:c}")]

        public decimal Total { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string PaymentCode { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string UserId { get; set; }

        //1 order contains many orderItems
        public List<OrderItem>? OrderItems { get; set; }
    }
}
