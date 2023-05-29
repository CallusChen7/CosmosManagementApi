using CosmosManagementApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<CosmosManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CosmosManagementDatabase")));
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
  options.AddPolicy("FrontEndPolicy",
      policy =>
      {
        policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
  //未登入時會自動導到這個網址
  option.LoginPath = new PathString("/api/Staff/NoLogin");
});

builder.Services.AddControllers().AddNewtonsoftJson(options => {
  options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors("FrontEndPolicy");

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization(); // 加入cookie Authorization 验证

app.Run();
