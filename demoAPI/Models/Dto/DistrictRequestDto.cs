using System.ComponentModel.DataAnnotations;

namespace demoAPI.Models.Dto
{
    public class DistrictRequestDto
    {
        public int stateid { get; set; }

        [Required]
        public string districtname { get; set; } = string.Empty;
    }
}
