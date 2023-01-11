using ITG_Project.Models;
internal class Program
{
    private static void Main(string[] args)

    {
        // var context = new DataContext();
        // var x = new SupplierModel();
        // x.name="Metin1";
        // x.emailAddress = "metinguneyozturk@gmail.com";
        // x.phoneNumber="+905076625528";
        // context.Suppliers.Add(x);
        // context.SaveChanges();


        // var context = new DataContext();
        // var p = new ProductModel();
        // p.quantity=100;

        // p.price=15;
        // p.productName="DenemeUrunu4";
        // context.Products!.Add(p);
        // context.SaveChanges();



        // var p = context.Suppliers.Find(1);
        // Console.WriteLine(p);

        var builder = WebApplication.CreateBuilder(args);
        
        

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddAuthentication().AddCookie();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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