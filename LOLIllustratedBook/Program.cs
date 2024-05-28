using LOLIllustratedBook;
using LOLIllustratedBook.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

static string GetConnectionString(string dataSource, string userId, string password, string database)
    => $"Data Source={dataSource};Persist Security Info=True;" +
    $"User ID={userId};" +
    $"Password={password};" +
    $"TrustServerCertificate=true;" +
    $"Database={database}";

string commonSource = "juroserver.com";
string commonUserId = "SD24052301";
string commonPassword = "SD24052301";

string db_connection_string(string db) => GetConnectionString(commonSource, commonUserId, commonPassword, db);

builder.Services.AddDbContext<LOLIllustratedBook_DbContext>(options =>
    options.UseSqlServer(db_connection_string("LOLIllustratedBook")));
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoL}/{action=Menu}/{id?}");

app.Run();
