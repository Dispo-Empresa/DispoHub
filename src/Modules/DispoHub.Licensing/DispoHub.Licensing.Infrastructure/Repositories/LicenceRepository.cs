using DispoHub.Core.Infrastructure.Persistence.Repositories;
using DispoHub.Licensing.Domain.Repositories;
using DispoHub.Shared.Domain.Entities;
using DispoHub.Shared.Infrastructure.Persistence;

namespace DispoHub.Licensing.Infrastructure.Persistence.Repositories
{
    public class LicenceRepository : BaseRepository<Licence>, ILicenceRepository
    {
        private readonly DispoHubContext _dispoHubContext;

        public LicenceRepository(DispoHubContext dispoHubContext) : base(dispoHubContext)
        {
            _dispoHubContext = dispoHubContext;
        }

        public bool ExistsByCompanyId(long companyId)
            => _dispoHubContext.Licences.Any(x => x.CompanyId == companyId);

        public Licence GetByCompanyId(long companyId)
            => _dispoHubContext.Licences.FirstOrDefault(x => x.CompanyId == companyId);
    }
}