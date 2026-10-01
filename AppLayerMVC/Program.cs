using BLL;
using BLL.Service;
using DAL.EF;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// DI for DbContext
builder.Services.AddDbContext<TutorConnectContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

// DI For AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add Scope
builder.Services.AddScoped<CourseRepo>();
builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<DepartmentRepo>();
builder.Services.AddScoped<StudentRequestRepo>();
builder.Services.AddScoped<TutorOfferingRepo>();

builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<StudentRequestService>();
builder.Services.AddScoped<TutorOfferingService>();

// MVC 
builder.Services.AddScoped<LoginService>();

// Session Config.
builder.Services.AddDistributedMemoryCache(); // Stores session data in RAM
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session expiration 
    options.Cookie.HttpOnly = true; // Protects the session cookie from client-side scripts
    options.Cookie.IsEssential = true; // Crucial for GDPR/cookie consent compliance
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

// Enable Session middleware
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=HomePage}/{id?}");

app.Run();
