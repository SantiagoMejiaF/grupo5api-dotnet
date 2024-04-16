using Microsoft.EntityFrameworkCore;
using personapi_dotnet.DAO.Person;
using personapi_dotnet.DAO.Phone;
using personapi_dotnet.DAO.Profession;
using personapi_dotnet.Entities.Profession;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Services.Person;
using personapi_dotnet.Services.Profession;
using personapi_dotnet.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Registro de DbContext
builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de DAOs
builder.Services.AddScoped<IPersonDao, PersonDao>();
builder.Services.AddScoped<IProfessionDao, ProfessionDao>();
builder.Services.AddScoped<IPhoneDao, PhoneDao>();

// Registro de Servicios
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IProfessionService, ProfessionService>();
builder.Services.AddScoped<IPhoneService, PhoneService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure endpoints for Razor Pages and API controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages(); 
    endpoints.MapControllers(); 
});

app.Run();
