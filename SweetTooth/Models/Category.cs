using System.ComponentModel.DataAnnotations;

namespace SweetTooth.Models
{
    public class Category
    {
        //all primary keys should be called Id or class name followed by Id (CategoryId)
    
        public int CategoryId { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a fantastic category name")]
        public string Name { get; set; }

        //1 category can have different products
        public List<Product>? Products { get; set; }

    }
}
