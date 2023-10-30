using DispoHub.Core.Domain.Repositories;

namespace DispoHub.Licence.Domain.Repositories
{
    public interface ILicenceRepository : IBaseRepository<Core.Domain.Entities.Licence>
    {
        bool ExistsByCompanyId(long companyId);
        Core.Domain.Entities.Licence GetByCompanyId(long companyId);
    }
}