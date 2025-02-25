using DAL.DataAccess;
using GestionClinica.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(provider => builder.Configuration.GetConnectionString("SQLConnection"));

builder.Services.AddTransient<MedicoRepository<Medico>>();
builder.Services.AddTransient<MedicoRepository<Especialidad>>();
//builder.Services.AddTransient<PacienteRepository<Paciente>>();
//builder.Services.AddTransient<CitaRepository<Cita>>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Citas",
    pattern: "{controller=Citas}/{action=Index}"

    );

app.MapControllerRoute(
    name: "Medicos",
    pattern: "{controller=Medicos}/{action=Index}"
    );

app.MapControllerRoute(
    name: "Pacientes",
    pattern: "{controller=Pacientes}/{action=Index}"
    );

app.Run();
