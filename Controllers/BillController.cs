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
    public class BillController : Controller
    {
        private readonly DataContext _datacontext;

        public BillController()
        {
            _datacontext = new DataContext();
        }



       

        [HttpPost]
        [Route("GenerateBill")]
        public async Task<ActionResult<BillModel>> generateBill(int wantedProduct, int desiredQuant)
        {
            BillModel generatedBill = new BillModel();
            var currRetailer = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.AuthenticationInstant).Value);
            var product = _datacontext.Products.FirstOrDefault(p => p.productId == wantedProduct);
            if (currRetailer == null || product == null) { return NotFound(); }


            generatedBill.billedproduct = product;
            generatedBill.retailerId = currRetailer;
            generatedBill.supplierId = product.supplierId;
            generatedBill.totalAmount = desiredQuant;
            
            product.quantity = product.quantity-desiredQuant;



            _datacontext.Bills.Add(generatedBill);
            _datacontext.SaveChanges();
            return Ok(wantedProduct);
        }


    }
}
