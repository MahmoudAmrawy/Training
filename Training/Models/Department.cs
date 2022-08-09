using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Training.Models
{
    [Table("Department", Schema ="dbo")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "DepartmentId")]
        public int IdDepartment { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        [Display(Name = "NameDeparment")]
        public string NameDeparment { get; set; }

    }
}
