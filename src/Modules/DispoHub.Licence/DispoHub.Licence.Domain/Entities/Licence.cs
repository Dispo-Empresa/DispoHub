using DispoHub.Core.Domain.Entities;
using DispoHub.Licence.Domain.Enums;

namespace DispoHub.Licence.Domain.Entities
{
    public class Licence : Base
    {
        public bool Active { get;set; }
        public string Key { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public eLicenceType Type { get; set; }
    }
}
