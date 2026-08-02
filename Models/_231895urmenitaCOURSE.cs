using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _231895urmenitaMVCCRUDOPERATION.Models
{
    [Table("231895urmenitaCOURSE")]
    public class _231895urmenitaCOURSE
    {
        [Key]
        public int COURSEID { get; set; }

        [Required, MaxLength(100)]
        public string DESCRIPTION { get; set; } = string.Empty;

        // Navigation is OPTIONAL – don't validate it on create
        public ICollection<_231895urmenitaSTUDENT>? Students { get; set; }
    }
}
