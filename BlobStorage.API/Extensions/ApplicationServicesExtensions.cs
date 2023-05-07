using Azure.Storage.Blobs;
using BlobStorage.API.Services;

namespace BlobStorage.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddBlobStorageService(this IServiceCollection services,
                                IConfiguration config)
        {

            services.AddSingleton(x =>
            {
                var connectionString = config.GetConnectionString("BlobStorageConnection");
                return new BlobServiceClient(connectionString);
            });

            return services;
        }

        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();

            return services;
        }
    }
}
