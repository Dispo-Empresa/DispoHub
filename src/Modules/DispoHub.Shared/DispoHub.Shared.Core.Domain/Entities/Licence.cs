using DispoHub.Shared.Domain.Enums;

namespace DispoHub.Shared.Domain.Entities
{
    public class Licence : EntityBase
    {
        public long Id { get; set; }
        public bool Active { get; set; }
        public string Key { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public eLicenceType Type { get; set; }
        public long CompanyId { get; set; }

        public Company Company { get; set; }
    }
}