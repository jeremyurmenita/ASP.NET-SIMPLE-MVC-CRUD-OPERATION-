using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _231895urmenitaMVCCRUDOPERATION.Models
{
    [Table("231895urmenitaSTUDENT")]
    public class _231895urmenitaSTUDENT
    {
        [Key]
        public int STUDENTID { get; set; }

        [Required, MaxLength(50)]
        public string FNAME { get; set; }

        [Required, MaxLength(50)]
        public string LNAME { get; set; }

        [MaxLength(50)]
        public string? MNAME { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime BDAY { get; set; }

        [Required, MaxLength(10)]
        public string GENDER { get; set; }

        // user must choose a course (COURSEID > 0)
        [Range(1, int.MaxValue, ErrorMessage = "Please select a course.")]
        public int COURSEID { get; set; }

        // IMPORTANT: make navigation property nullable so it is NOT [Required]
        [ForeignKey("COURSEID")]
        public _231895urmenitaCOURSE? Course { get; set; }
    }
}
