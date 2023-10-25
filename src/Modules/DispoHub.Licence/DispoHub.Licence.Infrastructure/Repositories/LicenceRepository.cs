using DispoHub.Core.Infrastructure;
using DispoHub.Core.Infrastructure.Repositories;
using DispoHub.Licence.Domain.Repositories;

namespace DispoHub.Licence.Infrastructure.Repositories
{
    public class LicenceRepository : BaseRepository<Core.Domain.Entities.Licence, CoreContext>, ILicenceRepository
    {
        private readonly CoreContext _coreContext;

        public LicenceRepository(CoreContext context) : base(context)
        {
            _coreContext = context;
        }

        public Core.Domain.Entities.Licence GetByCompanyId(long companyId)
            => _coreContext.Licences.FirstOrDefault(x => x.CompanyId == companyId);
    }
}