using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Extenzije;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAplikacijaCORS();

builder.Services.AddDbContext<AplikacijaContext>(AppCont =>
AppCont.UseSqlServer(builder.Configuration.GetConnectionString(name: "AplikacijaContext")));


var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.UseDefaultFiles();
app.UseDeveloperExceptionPage();
app.MapFallbackToFile("index.html");

app.Run();
