using Microsoft.EntityFrameworkCore;
using WebMarke_App.Data;
using WebMarke_App.Models.ViewModel;


//var c = new FibSeries().Take(10_00000).ToList();
//foreach (var item in c)
//{
//    if(item > 1000)
//    {
//        break;
//    }

//    Console.WriteLine(item);
//}

//foreach (var item in c)
//{
//    if (item > 1000)
//    {
//        break;
//    }

//    Console.WriteLine(item);
//}



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DBConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
