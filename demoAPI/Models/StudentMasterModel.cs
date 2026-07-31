using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoAPI.Models
{
    public class StudentMasterModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studid { get; set; }
        public string studname { get; set; } = string.Empty;
        public int age { get; set; }


    }
}
