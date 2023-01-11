using System.ComponentModel.DataAnnotations;
namespace ITG_Project.Models
{
    public class ProductModel
    {
        [Key]
        public int productId { get; set; }
        [Required]
        [MaxLength(150)]
        public string? productName { get; set; }
        [Required]
        
        public int quantity { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}


