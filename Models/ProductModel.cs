using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ITG_Project.Models
{
    public class ProductModel
    {
        
        // [PrimaryKey]//Pk
        [Key]
        public int productId { get; set; }
        
        [MaxLength(150)]
        public string? productName { get; set; }
       
        
        public int quantity { get; set; }
        
        public decimal price { get; set; }

        public int? retailerId{get;set;}
        
         //Fk
        public int supplierId{get;set;}
        
        // public virtual ICollection<ProductModel>? supplierProducts {get;set;}
        // public virtual ICollection<ProductModel>? retailerProducts {get;set;}

        // public RetailerModel? retailer{get; set;}

        // public SupplierModel? supplier{get;set;}

    }
}


