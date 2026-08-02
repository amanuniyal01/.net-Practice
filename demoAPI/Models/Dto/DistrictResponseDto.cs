using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoAPI.Models.Dto
{
    public class DistrictResponseDto
    {
        public int districtid { get; set; }

        public int stateid { get; set; }
        public string districtname { get; set; } = string.Empty;
    }
}
