using System.ComponentModel.DataAnnotations;

namespace ITG_Project.Models
{
public class BillModel
{
    [Key]
    public int billId{get; set;}
    [Required]
   
    public ProductModel? billedproduct { get; set; }
    [Required]

    public int totalAmount { get; set; }
    public int retailerId{get; set;}
    public int supplierId{get;set;}
   


   
}
}