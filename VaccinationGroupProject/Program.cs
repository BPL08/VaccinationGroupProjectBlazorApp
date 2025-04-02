using DAO.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Repository;
using VaccinationGroupProject.Components;
using Blazored.SessionStorage;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IVaccineCenterRepository, VaccineCenterRepository>();
builder.Services.AddScoped<IVaccineBatchRepository, VaccineBatchRepository>();
builder.Services.AddScoped<IChildrenProfileRepository, ChildrenProfileRepository>();
builder.Services.AddScoped<IVaccineHistoryRepository, VaccineHistoryRepository>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IVaccineCategoryRepository, VaccineCategoryRepository>();
builder.Services.AddScoped<IVaccinePackageDetailRepository, VaccinePackageDetailRepository>();
builder.Services.AddScoped<IVaccinePackageRepository, VaccinePackageRepository>();
builder.Services.AddBlazoredSessionStorage();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
