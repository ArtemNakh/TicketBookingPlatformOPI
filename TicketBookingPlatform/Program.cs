using Microsoft.EntityFrameworkCore;
using TicketBookingPlatform.Core.Interfaces;
using TicketBookingPlatform.Core.Services;
using TicketBookingPlatform.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TicketBookingPlatformContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Local")));

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IPlaceService, PlaceService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAdministrationService, AdministrationService>();
builder.Services.AddTransient<IReservationService, ReservationService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Таймаут сесії
});


builder.Services.AddControllersWithViews();

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

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
