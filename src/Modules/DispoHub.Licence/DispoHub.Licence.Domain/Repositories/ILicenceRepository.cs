using DispoHub.Core.Domain.Repositories;

namespace DispoHub.Licence.Domain.Repositories
{
    public interface ILicenceRepository : IBaseRepository<Core.Domain.Entities.Licence>
    {
        Core.Domain.Entities.Licence GetByCompanyId(long companyId);
    }
}