using DispoHub.Core.Infrastructure.Repositories;
using DispoHub.Licence.Domain.Repositories;

namespace DispoHub.Licence.Infrastructure.Repositories
{
    public class LicenceRepository : BaseRepository<Domain.Entities.Licence, LicenceContext>, ILicenceRepository
    {
        private readonly LicenceContext _licenceContext;

        public LicenceRepository(LicenceContext context, LicenceContext licenceContext) : base(context)
        {
            _licenceContext = licenceContext;
        }
    }
}
