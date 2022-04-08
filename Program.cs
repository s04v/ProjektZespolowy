using AutoMapper;
using FindJobWebApi.AutoMapper;
using FindJobWebApi.DataBase;
using FindJobWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:DataBase"];
builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddAuthentication("OAuth").
    AddJwtBearer("OAuth", config => 
    {
        
    });




builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddSingleton(AutoMapperConfiguration.Initialize());

builder.Services.AddControllers();
//builder.Services.AddScoped<ITokenService, TokenService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
