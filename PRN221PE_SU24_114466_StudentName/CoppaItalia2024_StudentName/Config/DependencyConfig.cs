using ConsultingKoiFish.DAL.Repositories;
using ConsultingKoiFish.DAL.UnitOfWork;

namespace CoppaItalia2024_StudentName.Config;

public class DependencyConfig
{
    public static void Register(IServiceCollection services)
    {
        //FS.DAL
        services.AddTransient(typeof(IRepoBase<>), typeof(RepoBase<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    }
}