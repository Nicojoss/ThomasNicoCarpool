using ThomasNicoCarpool.DAL;
using ThomasNicoCarpool.DAL.IDAL;

var builder = WebApplication.CreateBuilder(args);

// Pour activer la connection string dans appsettings.jsons
string connectionString = builder.Configuration.GetConnectionString("default");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUserDAL>(ud => new UserDAL(connectionString));
builder.Services.AddTransient<IRegistrationDAL>(regd => new RegistrationDAL(connectionString));
builder.Services.AddTransient<IRequestDAL>(reqd => new RequestDAL(connectionString));
builder.Services.AddTransient<IReviewDAL>(revd => new ReviewDAL(connectionString));
builder.Services.AddTransient<IVehicleDAL>(vd => new VehicleDAL(connectionString));
builder.Services.AddTransient<ICarpoolDAL>(cd => new CarpoolDAL(connectionString));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

builder.Services.AddDistributedMemoryCache();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
