using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ITG_Project.Models
{
    public class ProductModel
    {
        
        //Pk
        [Key]
        public int productId { get; set; }
        
        [MaxLength(150)]
        public string? productName { get; set; }
       
        
        public int quantity { get; set; }
        
        public decimal price { get; set; }

        
         //Fk
        public int supplierId{get;set;}

        public string productImageURL{get;set;}="https://i.ibb.co/47jDBbg/Default-Image.png";
        
        

    }
}


