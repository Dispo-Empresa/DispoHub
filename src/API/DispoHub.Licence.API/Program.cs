using DispoHub.Core.Infrastructure;
using DispoHub.Licence.Infrastructure;
using DispoHub.Licence.Infrastructure.Ioc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Injections

Injector.InjectIoCServices(builder.Services);
builder.Services.AddSingleton(x => builder.Configuration);

#endregion

#region Database

builder.Services.AddDbContext<CoreContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DispoDefaultConnection")), ServiceLifetime.Transient);

builder.Services.AddDbContext<LicenceContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DispoDefaultConnection")), ServiceLifetime.Transient);

#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
