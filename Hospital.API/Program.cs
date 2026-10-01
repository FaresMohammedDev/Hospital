using FluentValidation;
using FluentValidation.AspNetCore;
using Hospital.BL.Services.Implementation;
using Hospital.BL.Services.Interfaces;
using Hospital.BL.Validators.Doctor;
using Hospital.BL.Validators.Patient;
using Hospital.BL.Validators.Treatment;
using Hospital.DAL;
using Hospital.DAL.Models;
using Hospital.DAL.Repository.Implementation;
using Hospital.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration.GetConnectionString("HospitalDB");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<ITreatmentRepo, TreatmentRepo>();
builder.Services.AddScoped(typeof(IGenericRepo<>), (typeof(GenericRepo<>)));

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ITreatmentService, TreatmentService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTreatmentValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTreatmentValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateDoctorValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateDoctorValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePatientValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdatePatientValidator>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// 2. ≈⁄œ«œ«  «·»«”Ê—œ («Œ Ì«—Ì ⁄‘«‰ ‰”Â· «· ” )
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
});

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
