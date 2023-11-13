using DispoHub.Core.Domain.Repositories;
using DispoHub.Shared.Domain.Entities;

namespace DispoHub.Licensing.Domain.Repositories
{
    public interface ILicenceRepository : IBaseRepository<Licence>
    {
        bool ExistsByCompanyId(long companyId);

        Licence GetByCompanyId(long companyId);
    }
}