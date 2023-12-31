﻿using DispoHub.Shared.Domain.Enums;

namespace DispoHub.API.Models
{
    public class GetLicenceResponse
    {
        public string Key { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public eLicenceType Type { get; set; }
    }
}