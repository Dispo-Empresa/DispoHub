using DispoHub.Core.Infrastructure;
using DispoHub.Licence.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Injections

DispoHub.Core.Infrastructure.Ioc.Injector.InjectIoCServices(builder.Services);
DispoHub.Licence.Infrastructure.Ioc.Injector.InjectIoCServices(builder.Services);
builder.Services.AddSingleton(x => builder.Configuration);

#endregion Injections

#region Database

builder.Services.AddDbContext<CoreContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DispoDefaultConnection")), ServiceLifetime.Transient);

builder.Services.AddDbContext<LicenceContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DispoDefaultConnection")), ServiceLifetime.Transient);

#endregion Database

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