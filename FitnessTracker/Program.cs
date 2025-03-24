var builder = WebApplication.CreateBuilder(args);

//  Add MVC and API controllers
builder.Services.AddControllersWithViews(); // For Views (MVC)
builder.Services.AddControllers();          // For API Controllers

//  CORS Setup (Allow all origins — for development)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

//  Environment-specific config
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//  Enable CORS and Authorization
app.UseCors("AllowAll");
app.UseAuthorization();

//  Route for MVC controllers (e.g. HomeController)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//  Route for API controllers
app.MapControllers();

app.Run();