using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoAPI.Models.Entity
{
    public class DistrictEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int districtid { get; set; }

        public int stateid { get; set; }

        [Required]
        public string districtname { get; set; } = string.Empty;
    }
}
