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

        public async Task<ActionResult<ProductModel[]>> viewProducts()
        {   
            


            var products = _datacontext.Products;


            var productsasJSONArray = products;

            if (productsasJSONArray == null) { return NotFound(); }

            return Ok(productsasJSONArray);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductModel>> viewProduct(int productId)
        { //içinde Product Quantity de dönsün
            // if(Request.Cookies["key"]==null){return BadRequest();}
            // var user = Request.Cookies["Cookies"].Value;
            //var products = _datacontext.Products.SelectMany(g=> g.productId);

            var product = _datacontext.Products.FirstOrDefault(p => p.productId == productId);
            if (product == null) { return BadRequest(); }



            return product;
        }



        [HttpPost]
        [Route("CreateProduct")]
        public async Task<ActionResult<string>> PostProduct(productDTO newProduct)

        {
            var supPhone = HttpContext.User.Claims.FirstOrDefault(y=> y.Type == ClaimTypes.Authentication).Value;
            var supId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.AuthenticationInstant).Value);
            var sup = _datacontext.Suppliers!.FirstOrDefault(p=> p.supplierId == supId && p.phoneNumber.Contains(supPhone));
            if (sup == null) { return NotFound(); }



            var produc2beAdded = new ProductModel();

            produc2beAdded.productName = newProduct.productName;
            produc2beAdded.price = newProduct.price;
            produc2beAdded.quantity = newProduct.quantity;
            produc2beAdded.supplierId = supId;
            
            Uri uriResult;
            bool result = Uri.TryCreate(newProduct.image, 
            UriKind.Absolute, out uriResult) 
            && uriResult.Scheme == Uri.UriSchemeHttp;
            
            produc2beAdded.productImageURL=result ? uriResult.ToString(): produc2beAdded.productImageURL; //Uploaded image Url Should be provieded


            var controlProduct = _datacontext.Products!.FirstOrDefault(p => p.productName == newProduct.productName);
            if (controlProduct != null) { return "Product exists"; }

            _datacontext.Products!.Add(produc2beAdded);
            _datacontext.SaveChanges();
            return "Success";
        }


        [HttpDelete("{productId}")]
        public async Task<ActionResult<string>> Delete(int productId)
        {
            var supPhone = HttpContext.User.Claims.FirstOrDefault(y=> y.Type == ClaimTypes.Authentication).Value;
            var supId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.AuthenticationInstant).Value);
            var sup = _datacontext.Suppliers.FirstOrDefault(p=> p.supplierId == supId && p.phoneNumber.Contains(supPhone));
            if (sup == null) { return NotFound(); }
            
           
            var product = _datacontext.Products.FirstOrDefault(p => p.productId == productId && p.supplierId == supId);
            if (product == null) { return BadRequest(); }

            _datacontext.Remove(product);
            _datacontext.SaveChanges();

            return "Deleted Succesfully";

        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult<string>> UpdateProduct(int productid, int updatedquantity)
        { 
            var supPhone = HttpContext.User.Claims.FirstOrDefault(y=> y.Type == ClaimTypes.Authentication).Value;
            var supId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.AuthenticationInstant).Value);
            var sup = _datacontext.Suppliers.FirstOrDefault(p=> p.supplierId == supId && p.phoneNumber.Contains(supPhone));
            if (sup == null) { return NotFound(); }



            
           
            var existingProduct = _datacontext.Products!.FirstOrDefault(p=> p.productId==productid && p.supplierId ==supId);
            if(existingProduct==null){return BadRequest();}

            
            existingProduct.quantity=updatedquantity;
            _datacontext.SaveChanges();


            return "Success";
        }





        // [HttpGet]
        // [Route("deneme")]
        // public int Deneme()
        // { //içinde Product Quantity de dönsün
        //   // if(Request.Cookies["key"]==null){return BadRequest();}
        //   // var user = Request.Cookies["Cookies"].Value;

        //     var value = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.AuthenticationInstant).Value;

        //     var supplierId = Int32.Parse(value);

        //     return supplierId;
        // }


    }
}