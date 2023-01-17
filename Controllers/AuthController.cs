using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITG_Project.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ITG_Project.Controllers




{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public DataContext _datacontext;

        public AuthController()
        {
            _datacontext = new DataContext();
        }
 


        //SupplierLogin
        [HttpPost]
        [Route("SupplierLogin")]
        public async Task<ActionResult<SupplierModel>> sLogin([FromBody] loginDTO login)
        {
            var supplier = _datacontext.Suppliers!.FirstOrDefault(p => p.emailAddress == login.email );
            if (null == supplier) { return NotFound(); }
                
            var claims = new List<Claim>{
            new Claim(ClaimTypes.AuthenticationInstant, supplier.supplierId.ToString()),
            new Claim(ClaimTypes.Authentication, supplier.phoneNumber!),
           

         };
         
            var claimIdentity = new ClaimsIdentity(claims, authenticationType: "Login");
            

            await Request.HttpContext.SignInAsync(
               "Cookies",
               new ClaimsPrincipal(
                  claimIdentity));
                  
                  
            return supplier;





        }

        [HttpPost]
        [Route("RetailerLogin")]
        public async Task<ActionResult<RetailerModel>> rLogin([FromBody] loginDTO login)
        {
               var retailer = _datacontext.Retailers!.FirstOrDefault(p => p.email == login.email);
            if (null == retailer) { return NotFound(); }
                
            var claims = new List<Claim>{
            new Claim(ClaimTypes.AuthenticationInstant, retailer.retailerId.ToString()),
            new Claim(ClaimTypes.Authentication,retailer.phoneNumber!),

         };
         
            var claimIdentity = new ClaimsIdentity(claims, authenticationType: "Login");
            

            await Request.HttpContext.SignInAsync(
               "Cookies",
               new ClaimsPrincipal(
                  claimIdentity));
                  
                  
            return retailer;




        }



        //SupplierRegister
        [HttpPost]
        [Route("SupplierRegister")]
        public  async Task<ActionResult<string>> sRegister([FromBody] sregisterDTO sregister)
        {
         //SUPPLIERREGISTER
            if(sregister.email==null || sregister.name == null || sregister.phoneNumber==null){return BadRequest();}
             var newAccount = new SupplierModel();
             newAccount.emailAddress = sregister.email;
             newAccount.name = sregister.name;
             newAccount.phoneNumber=sregister.phoneNumber;
             
             var existingAccount = _datacontext.Suppliers.FirstOrDefault(p => p.emailAddress == sregister.email);
            if (null != existingAccount) { return "Account with the same email exists";  }//Early exit.
            
            // DataContext sregistercontext = new DataContext();
            // sregistercontext.Add(newSupplier);
            // sregistercontext.SaveChanges();
           
            
             _datacontext.Suppliers!.Add(newAccount);
            _datacontext.SaveChanges();
            return "Supplier Account Created"; 


        }


        //RetailerRegister
        [HttpPost]
        [Route("RetailerRegister")]
        public async Task<ActionResult<string>> rRegister([FromBody] rregisterDTO rregister)
        {
            if(rregister.email==null || rregister.phoneNumber==null){return BadRequest();}
            var newAccount = new RetailerModel();
            newAccount.email = rregister.email;
            newAccount.phoneNumber = rregister.phoneNumber;


            //Fail
            var existingAccount = _datacontext.Retailers!.FirstOrDefault(p=> p.email == newAccount.email);
            if(existingAccount!=null) {return "Account with the same email address exists";}

         //Success
             _datacontext.Retailers!.Add(newAccount);
            _datacontext.SaveChanges();
            return "Retailer Account Created"; 
        }








    }
}

//   public List<Entitiy> Entities = new List<Entitiy>
//         public class Entitiy
// {
//  public Guid Id { get; set; }

//          public string? Title { get; set; }

//          public DateTime Date { get; set; }

//          public string? Description { get; set; }

//          public string? Category { get; set; }

//          public string? City { get; set; }

//          public string? Venue { get; set; }


// }
