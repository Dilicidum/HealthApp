using Application;
using Carter;
using Domain.Factories;
using Domain.Persistance;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
builder.Services.AddControllers();
builder.Services.AddDbContext<IApplicationContext,HealthDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
            options.SignIn.RequireConfirmedAccount = false;
        }).AddEntityFrameworkStores<HealthDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCarter();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDiaryFactory,DiaryFactory>();
builder.Services.AddScoped<ILearningItemFactory,LearningItemFactory>();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();
app.MapHealthChecks("/health");
app.MapCarter();
app.MapControllers();

app.Run();