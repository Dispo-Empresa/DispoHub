using DispoHub.Shared.Domain.Enums;

namespace DispoHub.Licensing.Application.Response
{
    public class LicenceResponse
    {
        public string Key { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public eLicenceType Type { get; set; }
    }
}