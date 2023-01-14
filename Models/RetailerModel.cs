using System.ComponentModel.DataAnnotations;

namespace ITG_Project.Models
{
public class RetailerModel
{
    [Key]
    public int retailerId { get; set; }

    [MaxLength(20)]
    
    public string? phoneNumber { get; set; }
    
    [MaxLength(150)]
    public string? email { get; set; } 

    public List<ProductModel>? retailerProducts{get;set;}


    //public int productId {get; set;}
    
}
}