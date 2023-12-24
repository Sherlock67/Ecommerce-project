using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using pandacommerce_bal.IService.ILoginsService;
using pandacommerce_bal.IService.INavigations;
using pandacommerce_bal.IService.IProductCategory;
using pandacommerce_bal.IService.IProducts;
using pandacommerce_bal.Services;
using pandacommerce_dal.Data;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Repository;
using pandacommerce_dal.StaticInfos;
using pandacommerceapi.Filter;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
;
builder.Services.AddTransient<IProduct,ProductRepository>();
builder.Services.AddTransient<IProductCategory,ProductCategoryRepository>();
builder.Services.AddTransient<IProductCategorysService,ProductCategoryService>();
builder.Services.AddTransient<INavCategory, NavCategoryRepository>();
builder.Services.AddTransient<INavService,NavCategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IModule, ModuleRepository>();
builder.Services.AddTransient<ILoginRepository, LoginRepository>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var configBuilder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
IConfiguration _configuration = configBuilder.Build();
StaticInfo.JwtKey = _configuration.GetValue<string>("Jwt:Key");
StaticInfo.JwtIssuer = _configuration.GetValue<string>("Jwt:Issuer");
StaticInfo.JwtAudience = _configuration.GetValue<string>("Jwt:Audience");
StaticInfo.JwtKeyExpireIn = _configuration.GetValue<int>("Jwt:ExpireIn");
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));
});
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = StaticInfo.JwtIssuer,
                    ValidAudience = StaticInfo.JwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticInfo.JwtKey))
                };
            });
builder.Services.AddMvc();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
app.Run();
