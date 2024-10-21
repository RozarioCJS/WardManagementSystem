using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models.Services;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Respository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add your application's data access and repository services
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IAdminRepository, AdminRepository>();

// Rozario's Services
builder.Services.AddTransient<IScriptDetailsRepo, ScriptDetailsRepo>();
builder.Services.AddTransient<IWardConsumableRepository, WardConsumableRepository>();
builder.Services.AddScoped<PDFService>();

// Ryan's Services
builder.Services.AddTransient<IPatientInstructionRepo, PatientInstructionRepo>();
builder.Services.AddTransient<IScriptRepo, ScriptRepo>();
builder.Services.AddTransient<IScriptDetailRepo, ScriptDetailRepo>();
builder.Services.AddTransient<IScheduleRepo, ScheduleRepo>();
builder.Services.AddTransient<IPatientFileRepo, PatientFileRepo>();
builder.Services.AddTransient<IVisitRepo, VisitRepo>();

// Kenneth's Services
builder.Services.AddTransient<INurseRepository, NurseRepository>();
builder.Services.AddTransient<ISisterNurseRepository, SisterNurseRepository>();
builder.Services.AddTransient<INurseScheduleRepository, NurseScheduleRepository>();

// Ayden's Services
builder.Services.AddTransient<IBedsRepository, BedsRepository>();
builder.Services.AddTransient<IAdmissionRepository, AdmissionRepository>();
builder.Services.AddTransient<IPatientFolderRepository, PatientFolderRepository>();
builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IWardRepository, WardRepository>();
<<<<<<< HEAD
builder.Services.AddTransient<IPatientMovementRepository, PatientMovementRepository>();
//To gain acces to HttpContext in the view
=======

// To gain access to HttpContext in the view
>>>>>>> 836b68f62d2dada37fe0173147a54056b3d5b163
builder.Services.AddHttpContextAccessor();

// Session and Cache configuration
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Ensure session is used here
app.UseAuthentication();
app.UseAuthorization();

// Define routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LandingPage}/{action=Home}/{id?}");

app.Run();
