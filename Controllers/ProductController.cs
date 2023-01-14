using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
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
            
            
            var products = _datacontext.Products;
            
        
            var productsasJSONArray = products;
            
            if(productsasJSONArray==null){return NotFound();}
            
            return Ok(productsasJSONArray);



            //Tüm dbsetini getiriyor, optimize edilmeli.



            // var currUser = HttpContext.User.Identity.Name;
           
            // return p;
            //verilen cookie ve claim ikilisi????
           
            
            // var p = _datacontext.Products;
            // if(p==null){return NoContent();}
            // return p;


            // return Ok(); 
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductModel>> GetProduct(int productId)
        { //içinde Product Quantity de dönsün
            // if(Request.Cookies["key"]==null){return BadRequest();}
            // var user = Request.Cookies["Cookies"].Value;
            //var products = _datacontext.Products.SelectMany(g=> g.productId);

            var product = _datacontext.Products.FirstOrDefault(p=> p.productId == productId);
            if(product==null){return BadRequest();}
             
             
            
            return product;
        }



        [HttpPost]
        public async Task<ActionResult<string>> PostProduct(productDTO newProduct)
        
        {
           var supId =Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.AuthenticationInstant).Value); 
           
                
            
            
            var produc2beAdded = new ProductModel();
            
            produc2beAdded.productName = newProduct.productName;
            produc2beAdded.price = newProduct.price;
            produc2beAdded.quantity = newProduct.quantity;
            produc2beAdded.supplierId = supId;


            var controlProduct = _datacontext.Products!.FirstOrDefault(p=> p.productName == newProduct.productName);
             if(controlProduct!=null){return "Product exists";}   

            _datacontext.Products!.Add(produc2beAdded);
            _datacontext.SaveChanges();
            return "Success";
        }

    
        [HttpDelete("{productId}")]
        public async Task<ActionResult<string>> Delete(int productId)
        {
            var product = _datacontext.Products.FirstOrDefault(p=> p.productId == productId);
            if(product==null){return BadRequest();}

            _datacontext.Remove(product);
            _datacontext.SaveChanges();

            return "Deleted Succesfully";
            
        }


        [HttpGet]
        [Route("deneme")]
        public int Deneme()
        { //içinde Product Quantity de dönsün
            // if(Request.Cookies["key"]==null){return BadRequest();}
            // var user = Request.Cookies["Cookies"].Value;
            
                     var value = HttpContext.User.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.AuthenticationInstant).Value;

             var supplierId = Int32.Parse(value);
            
            return supplierId;
        }


    }
}