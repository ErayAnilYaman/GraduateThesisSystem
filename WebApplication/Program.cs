
using BusinessCore.Abstract;
using BusinessCore.Concrete;
using Data.Abstract;
using Data.Concrete;
using Data.Db;
using Microsoft.AspNetCore.Identity;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllersWithViews();
        // Theses
        builder.Services.AddScoped<IThesisDal, EfThesisDal>();
        builder.Services.AddScoped<IThesisService, ThesisManager>();
        // University
        builder.Services.AddScoped<IUniversityDal, EfUniversityDal>();
        builder.Services.AddScoped<IUniversityService, UniversityManager>();

        // Institutes
        builder.Services.AddScoped<IInstituteDal, EfInstituteDal>();
        builder.Services.AddScoped<IInstituteService, InstituteManager>();
        // Institutes
        builder.Services.AddScoped<ISupervisorDal, EfSupervisorDal>();
        // Institutes
        builder.Services.AddScoped<IAuthorDal, EfAuthorDal>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        object addEntityFrameworkStores = builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoleValidator<ThesesContext>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}