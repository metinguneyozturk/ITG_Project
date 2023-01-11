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
      private readonly DataContext _datacontext;

      public AuthController()
      {
         _datacontext = new DataContext();
      }

    

        //SupplierLogin
        [HttpPost]
        [Route("SupplierLogin")]
        public async Task<ActionResult<SupplierModel>> sLogin([FromBody] loginDTO login )
        {
         var supplier = _datacontext.Suppliers.FirstOrDefault(p => p.emailAddress == login.email );
         if(null == supplier){return NotFound();}
         var claims = new List<Claim>{
            new Claim(ClaimTypes.Name, supplier.emailAddress),
            //ClaimTypes nedir

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
        public async Task<ActionResult<RetailerModel>> rLogin([FromBody] loginDTO login )
        {
         
         
         var retailer =   _datacontext.Retailers!.FirstOrDefault(p => p.email==login.email );
         if(null == retailer){return NotFound();}
         return retailer; //Early exit.



      
        }



          //SupplierRegister
        [HttpPost]
        [Route("SupplierRegister")]
        public String sRegister([FromBody] registerDTO register)
        {
           return null;
        }


         //RetailerRegister
         [HttpPost]
        [Route("RetailerRegister")]
        public String rRegister([FromBody] registerDTO register)
        {
           return null;
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
