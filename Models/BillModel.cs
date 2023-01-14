using System.ComponentModel.DataAnnotations;

namespace ITG_Project.Models
{
public class BillModel
{
    [Key]
    public int billId{get; set;}
    [Required]
    //cannot generate bill without product
    public ProductModel? billedproduct { get; set; }
    [Required]

    public int totalAmount { get; set; }
    // [Required]


    //public string productName { get; set; }
    // public decimal price { get; set; }
    // public int productQuantity { get; set; }
}
}