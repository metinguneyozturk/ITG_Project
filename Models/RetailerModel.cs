using System.ComponentModel.DataAnnotations;

namespace ITG_Project.Models
{
public class RetailerModel
{
    [Key]
    public int retailerId { get; set; }

    [MaxLength(20)]
    [Required]
    
    public string? phoneNumber { get; set; }
    
    [MaxLength(150)]
    public string? email { get; set; } 



   
    
}
}