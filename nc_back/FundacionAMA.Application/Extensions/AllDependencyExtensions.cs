using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Infrastructure.Persistence.Repository;

using Microsoft.Extensions.DependencyInjection;

namespace FundacionAMA.Application.Extensions;

public static class DependencyExtensions
{
    public static void AddAllDependencies(this IServiceCollection services)
    {


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //// Configuración para Login
        //services.AddLoginDependencies();

        //// Configuración para Invoice
        //services.AddInvoiceDependencies();

        // Puedes agregar más llamadas a otras extensiones aquí
    }
}