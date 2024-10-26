using BusinessLogic;
using BusinessObjects.Interfaces;
using DataAccess;
using DataAccess.Repositories.Generic;
using DataAccess.Repositories.Implementation;
using DataAccess.Repositories.Specific;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
);

builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderMealRepository, OrderMealRepository>();
builder.Services.AddScoped<IOrderMealDetailsRepository, OrderMealDetailsRepository>();

builder.Services.AddScoped(typeof(IGetRepository<>), typeof(GetRepository<>));
builder.Services.AddScoped(typeof(ICreateRepository<>), typeof(CreateRepository<>));
builder.Services.AddScoped(typeof(IRemoveRepository<>), typeof(RemoveRepository<>));


builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(
    typeof(DataAccess.Mapping.MealProfile),
    typeof(Presentation.Mapping.MealProfile)
);

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