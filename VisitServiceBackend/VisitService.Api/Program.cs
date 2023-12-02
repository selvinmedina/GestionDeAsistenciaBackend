using AutoMapper;
using EntityFramework.Infrastructure.Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VisitService.Api.Features.TiposTransportes;
using VisitService.Api.Features.Ubicaciones;
using VisitService.Api.Features.Visitas;
using VisitService.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql("name=PostgresConnection"));

builder.Services.AddIdentityApiEndpoints<IdentityUser>(options =>
{
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<UbicacionService>();
builder.Services.AddTransient<TipoTransporteService>();
builder.Services.AddTransient<VisitaService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql("name=PostgresConnection"));

builder.Services.AddScoped<IUnitOfWork, ApplicationUnitOfWork>();

builder.Services.AddAuthorization();

// add automapper based on .net 7.0 preview without startup.cs
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile<Mapeos>();
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("/identity")
    .MapIdentityApi<IdentityUser>();

app.UseAuthorization();

app.MapControllers();

app.Run();
