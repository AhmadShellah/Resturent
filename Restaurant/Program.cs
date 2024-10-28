using Contracts.InterFacses;
using DataCenter;
using DataCenter.GenricRepo;
using DataCenter.MealManagement;
using DataCenter.MealsManagement;
using DataCenter.OrderManagement;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//Add DataBase 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IMealRepositoryService, MealRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepositoryService, OrderRepository>();

builder.Services.AddScoped(typeof(IGetRepository<>), typeof(GetRepository<>));
builder.Services.AddScoped(typeof(ICreateRepository<>), typeof(CreateRepository<>));
builder.Services.AddScoped(typeof(IUpdateRepository<>), typeof(UpdateRepository<>));
builder.Services.AddScoped(typeof(IRemoveRepository<>), typeof(RemoveRepository<>));
builder.Services.AddScoped<ISaveChanges, SaveChangeRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(DataCenter.AutoMapper.AutoMapperProfile));

var app = builder.Build();

//app.UseSqlServer();

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
