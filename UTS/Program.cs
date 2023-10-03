using Microsoft.EntityFrameworkCore;
//Referencia para la autentificacion por galletas
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
/*using UTS.Models.DB;*/

var builder = WebApplication.CreateBuilder(args);


//aqui le movemos para que agarre por coookies
//Configuracion de la autentificacion
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/LoginUsuario/Login"; //Ruta donde iniciara la aplicacion
        options.ExpireTimeSpan = TimeSpan.FromMinutes(1);//tiempo para que expire la sesion
    });


/*builder.Services.AddDbContext<AulasUtsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AulasUTSContext"));
}); */
// Add services to the container.
//Borrar caché para sesión
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None,
        });
});

var app = builder.Build();

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
//Agregar el middleware UseAuthentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoginUsuario}/{action=Login}/{id?}");

app.Run();