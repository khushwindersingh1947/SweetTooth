using System.ComponentModel.DataAnnotations;

namespace SweetTooth.Models
{
    public class Category
    {
        //all primary keys should be called Id or class name followed by Id (CategoryId)
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
 
    }
}
