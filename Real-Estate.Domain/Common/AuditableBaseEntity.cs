using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Domain.Common
{
    public class AuditableBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
