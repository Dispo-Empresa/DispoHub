using DispoHub.Core.Domain.Entities;
using DispoHub.Core.Domain.Repositories;

namespace DispoHub.Core.Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company, CoreContext>, ICompanyRepository
    {
        private readonly CoreContext _coreContext;

        public CompanyRepository(CoreContext context) : base(context)
        {
            _coreContext = context;
        }
    }
}
