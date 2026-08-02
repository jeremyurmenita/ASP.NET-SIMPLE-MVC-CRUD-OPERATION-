using Microsoft.EntityFrameworkCore;
using _231895urmenitaMVCCRUDOPERATION.Data;

var builder = WebApplication.CreateBuilder(args);

// DB CONNECTION
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC + SESSION
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

// allow session inside _Layout.cshtml
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

// default: go to Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
