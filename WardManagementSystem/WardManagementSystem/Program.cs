using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models.Services;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Respository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("connectionString");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IAdminRepository, AdminRepository>();
//Rozario's Services
builder.Services.AddTransient<IScriptDetailsRepo, ScriptDetailsRepo>();
builder.Services.AddTransient<IWardConsumableRepository, WardConsumableRepository>();
builder.Services.AddScoped<PDFService>();
//Ryan's Services
builder.Services.AddTransient<IPatientInstructionRepo, PatientInstructionRepo>();
builder.Services.AddTransient<IScriptRepo, ScriptRepo>();
builder.Services.AddTransient<IScriptDetailRepo, ScriptDetailRepo>();
builder.Services.AddTransient<IScheduleRepo, ScheduleRepo>();
builder.Services.AddTransient<IPatientFileRepo, PatientFileRepo>();
builder.Services.AddTransient<IVisitRepo, VisitRepo>();
//Kenneth's Services
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<INurseRepository, NurseRepository>();
builder.Services.AddTransient<ISisterNurseRepository, SisterNurseRepository>();
builder.Services.AddTransient<INurseScheduleRepository, NurseScheduleRepository>();

//To gain acces to HttpContext in the view
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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession(); // Ensure session is used here
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LandingPage}/{action=Home}/{id?}");

app.Run();
