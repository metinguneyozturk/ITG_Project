using System.ComponentModel.DataAnnotations;

namespace ITG_Project.Models
{
public class BillModel
{
    [Key]
    public int billId{get; set;}
    [Required]
    
    public int productId { get; set; }
    [Required]

    public int totalAmount { get; set; }
    [Required]


    public ProductModel? billedProduct{get;set;}

    // public string productName { get; set; }
    // public decimal price { get; set; }
    // public int productQuantity { get; set; }
}
}