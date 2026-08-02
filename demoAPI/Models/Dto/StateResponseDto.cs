using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoAPI.Models.Dto
{
    public class StateResponseDto
    {
        public int stateid { get; set; }
      
        public string statename { get; set; } = String.Empty;
    }
}
