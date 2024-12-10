var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//configuration for cookie
builder .Services .AddHttpContextAccessor();
builder .Services .AddSingleton<IHttpContextAccessor , HttpContextAccessor>();

builder .Services .AddSession(options =>
{
    options .IdleTimeout = TimeSpan .FromMinutes(5);
    options .Cookie .IsEssential = true;
});
 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app .UseSession();//for session

app .MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
