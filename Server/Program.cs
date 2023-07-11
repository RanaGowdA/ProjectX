using CustomerRelationshipManagement.Data;
using CustomerRelationshipManagement.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddControllersWithViews();
services.AddRazorPages();

// Custom Services // 

#region Database Context Configuration

services.AddDbContextPool<AdminDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AdminDb")));

services.AddScoped<AdminDbContext>();

services.AddIdentity<AppUser, AppRole>(options => options.User.RequireUniqueEmail = false)
                .AddEntityFrameworkStores<AdminDbContext>()
                .AddDefaultTokenProviders();

#endregion Database Context Configuration

#region Authentication Configuration With JWT

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(op =>
{
    op.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ClockSkew = TimeSpan.Zero,
        ValidateActor = true
    };
});

// Cookie Auth

//services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth",
//    options =>
//    {
//        options.Cookie.Name = "MyCookieAuth";
//        options.LoginPath = "/Account/Login";
//        options.AccessDeniedPath = "/Account/AccessDenied";
//        options.ExpireTimeSpan = TimeSpan.FromSeconds(6);
//    });

#endregion Authentication Configuration With JWT

#region Authorization Configuration With Roles

services.AddAuthorization();

// Policy
// services.AddAuthorization(options =>
// {
//     options.AddPolicy("AdminOnly",
//         policy => policy.RequireClaim("Admin"));
//     options.AddPolicy("MustBelongToHRDept",
//         policy => policy.RequireClaim("Department", "HR"));
//     options.AddPolicy("HRManangerOnly",
//         policy => policy.RequireClaim("Department", "HR").RequireClaim("Mananger")
//         .Requirements.Add(new HRManagerProbitionRequirement(1)));
// });

#endregion Authorization Configuration With Roles


#region Repository



#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

#region To Enable Authentication & Authorization Capabilities

app.UseAuthentication();
app.UseAuthorization();

#endregion To Enable Authentication & Authorization Capabilities

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
