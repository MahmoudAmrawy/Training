using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Training.Models
{
    [Table("Employee", Schema="dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EmployeeId")]
        public int EmployeeId { get; set; }
        
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        [Display(Name ="UserName")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        [Display(Name ="Gender")]
        public string Gender { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "City")]
        public string City { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }

        [Display(Name = "Department")]
        [NotMapped]
        public string DepartmentName { get; set; }

        public virtual Department Department { get; set; }
    }
}
