using System.ComponentModel.DataAnnotations;

namespace demoAPI.Models.Dto
{
    public class StateRequestDto
    {
        [Required]
        public string statename { get; set; } = String.Empty;
    }
}
