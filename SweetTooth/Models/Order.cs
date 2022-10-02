﻿using System.ComponentModel.DataAnnotations;

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
        public string PostalCode { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string PaymentCode { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //1 order contains many orderItems
        public List<OrderItem>? OrderItems { get; set; }
    }
}
