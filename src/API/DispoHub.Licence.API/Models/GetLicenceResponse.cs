using DispoHub.Core.Domain.Enums;

namespace DispoHub.Licence.API.Models
{
    public class GetLicenceResponse
    {
        public string Key { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public eLicenceType Type { get; set; }
    }
}