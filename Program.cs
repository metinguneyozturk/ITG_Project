
using ITG_Project.Models;
internal class Program
{
    private static void Main(string[] args)

    {

        DataContext db = new DataContext();
        for(int i =1; i<51; i++){
        var supplier = new SupplierModel();
        var retailer = new RetailerModel();
        var product = new ProductModel();
        
        supplier.emailAddress =$"supplierEmailAddress{i}";
        supplier.name=$"supplierName{i}";
        supplier.phoneNumber=$"1234{i}";
        
        retailer.email=$"retailerEmailAddress{i}";
        retailer.phoneNumber=$"1234{1}";

        product.price=15;
        product.productName=$"product{i}";
        product.quantity=50;
        product.supplierId=1;
        
        db.Add(product);
        db.Add(supplier);
        db.Add(retailer);
        db.SaveChanges();
        }


        var builder = WebApplication.CreateBuilder(args);




        builder.Services.AddControllers();


        builder.Services.AddAuthentication().AddCookie();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}