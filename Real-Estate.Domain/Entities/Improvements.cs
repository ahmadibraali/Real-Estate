﻿using Real_Estate.Domain.Common;

namespace Real_Estate.Domain.Entities
{
    public class Improvements : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Properties>? Properties { get; set; }
    }
}
