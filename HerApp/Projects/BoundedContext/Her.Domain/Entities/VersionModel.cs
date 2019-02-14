using Her.Commons.Enums.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Her.Domain.Entities
{
    [Table("Version", Schema = "version")]
    public class VersionModel
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual VersionTypeEnum VersionType { get; set; }
        [StringLength(12)]
        public virtual string VersionNumber { get; set; }
        [StringLength(12)]
        public virtual string LastVersionNumber { get; set; }
        public virtual DateTime CreateDateTime { get; set; }
    }
}
