using System.Reflection;
using FIleExplorer.Demo.Application.FileStorage.Brokers;
using FIleExplorer.Demo.Application.FileStorage.Models.Settings;
using FIleExplorer.Demo.Application.FileStorage.Services;
using FileExplorer.Demo.Infrastructure.FileStorage.Brokers;
using FileExplorer.Demo.Infrastructure.FileStorage.Services;

namespace FileExplorer.Demo.Api.Configuration;

public static partial class HostConfiguration
{
    #region Builder Configuration

    private static WebApplicationBuilder AddMapping(this WebApplicationBuilder builder)
    {
        var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        
        assemblies.Add(Assembly.GetExecutingAssembly());

        builder.Services.AddAutoMapper(assemblies);
        
        return builder;
    }

    private static WebApplicationBuilder AddBrokers(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddSingleton<IDriverBroker, DriverBroker>()
            .AddSingleton<IDirectoryBroker, DirectoryBroker>()
            .AddSingleton<IFileBroker, FileBroker>();
        
        return builder;
    }

    private static WebApplicationBuilder AddFileStorageInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<FileFilterSettings>(builder.Configuration.GetSection(nameof(FileFilterSettings)));
        builder.Services.Configure<FileStorageSettings>(builder.Configuration.GetSection(nameof(FileFilterSettings)));

        builder
            .Services
            .AddSingleton<IDriveService, DriveService>()
            .AddSingleton<IDirectoryService, DirectoryService>()
            .AddSingleton<IFileService, FileService>();

        builder
            .Services
            .AddSingleton<IDirectoryProcessingService, DirectoryProcessingService>()
            .AddSingleton<IFileProcessingService, FileProcessingService>();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();
        
        return builder;
    }

    private static WebApplicationBuilder AddCustomCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });
        
        return builder;
    }

    #endregion

    #region Application configuration

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger().UseSwaggerUI();

        return app;
    }

    private static WebApplication UseCustomCors(this WebApplication app)
    {
        app.UseCors("CorsPolicy");
        
        return app;
    }

    private static WebApplication MapRoutes(this WebApplication app)
    {
        app.MapControllers();
        
        return app;
    }

    private static WebApplication UseFileStorage(this WebApplication app)
    {
        app.UseStaticFiles();
        
        return app;
    }
    #endregion
}
    
