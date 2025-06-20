using System.Text;
using EShop.Data.Abstract;
using EShop.Data.Concrete;
using EShop.Data.Concrete.Contexts;
using EShop.Data.Concrete.Repositories;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Services.Concrete;
using EShop.Services.Mapping;
using EShop.Shared.Configurations.Auth;
using EShop.Shared.Configurations.Email;
using LinqKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", p => p.WithOrigins(
        builder.Configuration.GetSection("AppUrl").Get<string[]>()![1]
    ).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
});

builder.Services.AddDbContext<EShopDbContext>(options =>
{
    options.UseSqlServer(
            builder.Configuration.GetConnectionString("RemoteConnection"))
        .WithExpressionExpanding();

});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<EShopDbContext>().AddDefaultTokenProviders();


builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.Configure<AppUrlConfig>(builder.Configuration.GetSection("AppUrl"));

var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig?.Issuer,
        ValidAudience = jwtConfig?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig?.Secret ?? ""))
    };
});



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IAuthService, AuthManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IEmailService, EmailManager>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserManager>();
builder.Services.AddScoped<IApplicationRoleService, ApplicationRoleManager>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }


app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
