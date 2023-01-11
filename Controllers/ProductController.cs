using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITG_Project.Models;



namespace ITG_Project.Controllers

{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [ApiController] 
    [Route("[controller]")]
    public class ProductController : Controller
    {
    private readonly DataContext _datacontext;

      public ProductController()
      {
         _datacontext = new DataContext();
      }

        [HttpGet]
      public async Task<ActionResult<ProductModel[]>>GetProducts()
        {
            var x = _datacontext.Products;
            var y = x!.ToArray();
            if(y==null){return NotFound();}
            
            return y;
            //Tüm listeyi db'i getiriyor, optimize edilmeli.



            // var currUser = HttpContext.User.Identity.Name;
           
            // return p;
            //verilen cookie ve claim ikilisi????
           
            
            //var p = _datacontext.Products;
            // if(p==null){return NoContent();}
            // return p;


            //return Ok(object); is another way
        }

        [HttpGet("{productId}")]
        public String GetProduct(int productId)
        { //içinde Product Quantity de dönsün
            return "";
        }



        [HttpPost]
        public String PostProduct()
        {

            return "";
        }

    
        [HttpDelete("{productId}")]
        public String Delete(int productId)
        {
            return "";
        }


    }
}