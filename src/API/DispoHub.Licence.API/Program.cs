using DispoHub.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Injections

DispoHub.Core.Infrastructure.Ioc.Injector.InjectIoCServices(builder.Services);
DispoHub.Licensing.Infrastructure.Ioc.Injector.InjectIoCServices(builder.Services);
DispoHub.Mensager.Ioc.Injector.InjectIocServices(builder.Services);
builder.Services.AddSingleton(x => builder.Configuration);

#endregion Injections

#region Database

builder.Services.AddDbContext<DispoHubContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DispoDefaultConnection")), ServiceLifetime.Transient);

#endregion Database

#region MediatR

foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}

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