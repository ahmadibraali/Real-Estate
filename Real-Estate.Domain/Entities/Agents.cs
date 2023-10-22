using Real_Estate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Domain.Entities
{
    public class Agents : AuditableBaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImagePath { get; set; }
        public int NumberOfProperties { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Properties>? Properties { get; set; }
    }
}
