using System.ComponentModel.DataAnnotations;

namespace demoAPI.Models.Dto
{
    public class StateDto
    {
        [Required]
        public string statename { get; set; } = String.Empty;
    }
}
