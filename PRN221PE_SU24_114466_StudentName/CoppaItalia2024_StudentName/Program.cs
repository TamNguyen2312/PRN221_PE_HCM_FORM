using CoppaItalia2024_StudentName.Config;
using FS.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoppaItalia2024_StudentName;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        
        //<===ADD DATABASE===>
        //<=====Set up policy=====>
        builder.Services.AddCors(opts =>
        {
            opts.AddPolicy("corspolicy",
                build => { build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); });
        });

        //<=====Add Database=====>
        var connectionString = builder.Configuration.GetConnectionString("CoppaItalia2024DB");
        builder.Services.AddDbContext<MasterDBContext>(opts => opts.UseSqlServer(connectionString));
        
        //<===DI===>
        DependencyConfig.Register(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCors("corspolicy");
        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}