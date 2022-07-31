using ComunicationClientAPP.Data;
using ComunicationClientAPP.Manager;
using ComunicationClientAPP.Session;
using Microsoft.AspNetCore.Authentication.Cookies;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    //options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddScoped<MySession>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddTransient<IChatManager, ChatManager>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        //options.AccessDeniedPath = "/Forbidden/";
    });
//builder.Services.AddMudServices(c => { c.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight; });
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseSession();
//app.Use(async delegate (HttpContext Context, Func<Task> Next)
//{
//    //this throwaway session variable will "prime" the SetString() method
//    //to allow it to be called after the response has started
//    var TempKey = Guid.NewGuid().ToString(); //create a random key
//    Context.Session.Set(TempKey, Array.Empty<byte>()); //set the throwaway session variable
//    Context.Session.Remove(TempKey); //remove the throwaway session variable
//    await Next(); //continue on with the request
//});
app.Run();
