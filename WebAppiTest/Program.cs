using Application;
using Infrastructure.Persistence;

var myPermissons = "_myAllowOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(config =>
//    {
//        config.AllowAnyMethod();
//        config.AllowAnyOrigin();
//        config.AllowAnyHeader();
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myPermissons, builder =>
    {
        builder.WithOrigins("http://localhost:4200")
         .AllowAnyMethod()
         .AllowAnyHeader();
    });
});

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructurePersistenceLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myPermissons);
app.UseAuthorization();

app.MapControllers();

app.Run();

//using WebAppiTest;

//WebApplication.CreateBuilder(args)
//    .CreateWebApplication()
//    .ConfigureWebApplication()
//    .Run();

