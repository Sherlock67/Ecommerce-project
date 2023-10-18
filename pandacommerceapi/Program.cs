using Microsoft.EntityFrameworkCore;
using pandacommerce_bal.Services;
using pandacommerce_dal.Data;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Repository;
using pandacommerceapi.Filter;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProduct,ProductRepository>();
builder.Services.AddTransient<IProductCategory,ProductCategoryRepository>();
builder.Services.AddTransient<ProductCategoryService>();
builder.Services.AddTransient<INavCategory, NavCategoryRepository>();
builder.Services.AddTransient<NavCategoryService>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
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
