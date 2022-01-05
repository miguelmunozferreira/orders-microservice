using AutoMapper;
using OrdersMicroservice.Api.Mapping;
using OrdersMicroservice.Core.Interfaces;
using OrdersMicroservice.Core.Services;
using OrdersMicroservice.Infrastructure;
using OrdersMicroservice.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<OrdersProcessingServiceOptions>(builder.Configuration.GetSection("Configuration"));
builder.Services.AddControllers();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddSingleton<IOrdersRespository, OrdersRespository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
