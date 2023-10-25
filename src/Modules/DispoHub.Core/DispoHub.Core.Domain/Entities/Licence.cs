using DispoHub.Core.Domain.Enums;

namespace DispoHub.Core.Domain.Entities
{
    public class Licence : Base
    {
        public bool Active { get; set; }
        public string Key { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public eLicenceType Type { get; set; }
        public long CompanyId { get; set; }

        public Company Company { get; set; }
    }
}