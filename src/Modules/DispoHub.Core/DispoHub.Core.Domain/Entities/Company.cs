using System.Net;

namespace DispoHub.Core.Domain.Entities
{
    public class Company : Base
    {
        public bool Active { get; set; }
        public string CorporateName { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsiblePhone { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
    }
}
