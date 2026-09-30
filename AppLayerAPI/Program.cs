using BLL;
using DAL.EF;
using DAL.Repository;
using BLL.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
