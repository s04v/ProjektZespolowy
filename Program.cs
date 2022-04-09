using FindJobWebApi;
using FindJobWebApi.AutoMapper;
using FindJobWebApi.DataBase;
using FindJobWebApi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:DataBase"];
builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString));


var jwtSection = builder.Configuration.GetSection("JWTSettings");
builder.Services.Configure<JWTSettings>(jwtSection);

var appSettings = jwtSection.Get<JWTSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie("Cookie", config =>
{
    config.LoginPath = "/company/signin";
    config.AccessDeniedPath = "/company/signin"; // temporary
});

builder.Services.AddAuthorization(conf =>
{
    conf.AddPolicy("Company", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "Company");
    });
    conf.AddPolicy("User", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "User");
    });
});



builder.Services.AddCors(options =>
{
    // need to be changed to .AddPolicy with name
    // and then use [EnableCors("Policy")]
    options.AddDefaultPolicy(policy => 
        {
            policy.WithOrigins("http://localhost:3000",
            "https://pz-findjob.herokuapp.com")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});


    //.AddJwtBearer(x =>
    //{
    //    x.RequireHttpsMetadata = true;
    //    x.SaveToken = true;
    //    x.TokenValidationParameters = new TokenValidationParameters
    //    {
    //        ValidateIssuerSigningKey = true,
    //        IssuerSigningKey = new SymmetricSecurityKey(key),
    //        ValidateIssuer = false,
    //        ValidateAudience = false,
    //        ClockSkew = TimeSpan.Zero
    //    };

    //});


builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddSingleton(AutoMapperConfiguration.Initialize());

builder.Services.AddControllers();
builder.Services.AddScoped<ITokenService, TokenService>();

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

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
