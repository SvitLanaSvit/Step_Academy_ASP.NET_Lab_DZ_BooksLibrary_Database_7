using Lab_DZ_BooksLibrary_7.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//mozno peremykatysja miz builder.Services.AddTransient<IRepository<Book>, BookDbRepository>();
//builder.Services.AddSingleton<IRepository<Book>, BookRepository>(); 

builder.Services.AddTransient<IRepository<Book>, BookDbRepository>(); //!!!
string? connStr = builder.Configuration.GetConnectionString("LibraryBooksASP");  //!!!
builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer(connStr)); //!!!

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
