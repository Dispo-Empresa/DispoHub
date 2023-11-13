using DispoHub.Core.Domain.Repositories;
using DispoHub.Shared.Domain.Entities;
using DispoHub.Shared.Infrastructure.Persistence;

namespace DispoHub.Core.Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly DispoHubContext _dispoHubContext;

        public CompanyRepository(DispoHubContext dispoHubContext) : base(dispoHubContext)
        {
            _dispoHubContext = dispoHubContext;
        }
    }
}