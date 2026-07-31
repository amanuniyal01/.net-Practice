using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoAPI.Models
{
    public class StudentMasterModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studid { get; set; }

        [Required (ErrorMessage = "Student Name is required")]
        [StringLength(50, MinimumLength = 1)]
        public string studname { get; set; } = string.Empty;
        [Required (ErrorMessage = "Student Age is Required.")]
        
        [Range(1,100,ErrorMessage =("Age must be between 1 and 100"))]
        public int age { get; set; }


    }
}
