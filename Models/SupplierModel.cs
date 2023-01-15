using System.ComponentModel.DataAnnotations;

namespace ITG_Project.Models
{
public class SupplierModel
{
    
    
    [Key] 
    public int supplierId { get; set; }
    
    [MaxLength(150)]
    public string? name{get;set;}
    [MaxLength(150)]
    public string emailAddress { get; set; } = string.Empty;
    [MaxLength(150)]
    [Required]
    public string? phoneNumber{get; set;}

    

    public ProductModel? product{get; set;}
}
}