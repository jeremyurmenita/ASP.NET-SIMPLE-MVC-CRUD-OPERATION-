using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _231895urmenitaMVCCRUDOPERATION.Models
{
    [Table("231895urmenitaUSER")]
    public class _231895urmenitaUSER
    {
        [Key]
        public int USERID { get; set; }

        [Required, MaxLength(50)]
        public string FNAME { get; set; }

        [Required, MaxLength(50)]
        public string LNAME { get; set; }

        [MaxLength(50)]
        public string? MNAME { get; set; }

        [Required, MaxLength(50)]
        public string USERNAME { get; set; }

        [Required, MaxLength(255)]
        public string PASSWORD { get; set; }
    }
}
