using ESIN.Clinic.Infrastructure.Context;

namespace ESIN.Clinic.Web.Extensions;

internal static class AppExtensions
{
    internal static void CreateDatabase(this IHost app)
    {
        var serviceScope = app.Services.CreateScope();
        var dataContext = serviceScope.ServiceProvider.GetService<ClinicDbContext>();
        dataContext?.Database.EnsureCreated();
    }
}