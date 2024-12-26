using Cours.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using ges_commande.Models;
using Cours.Services.Impl;

using Microsoft.EntityFrameworkCore;
using gestioncommande.Data.Fixtures;


var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("MysqlConnection")!;

builder.Services.AddDbContext<ApplicationDbContext>(options =>

            options.UseMySql(connectionString,

            new MySqlServerVersion(new Version(8, 0, 40))));
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IPersonneService, PersonneService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICommandeService, CommandeService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Access/Login"; // Chemin corrigé avec un '/'
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services= scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    Fixtures.   Initialize(services,context);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

// app.MapControllerRoute(
//     name: "user",
//     pattern: "User/{action=Index}/{id?}",
//     defaults: new { controller = "User", action = "Index" }
// );
// app.MapControllerRoute(
//     name: "commande",
//     pattern: "Commande/{action=Index}/{id?}",
//     defaults: new { controller = "Commande", action = "Index" }
// );
// app.MapControllerRoute(
//     name: "client",
//     pattern: "Client/{action=Index}/{id?}",
//     defaults: new { controller = "Client", action = "Index" }
// );



app.Run();
