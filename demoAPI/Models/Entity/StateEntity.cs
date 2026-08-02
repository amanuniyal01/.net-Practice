using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoAPI.Models.Entity
{
    public class StateEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stateid { get; set; }
        [Required]
        public string statename { get; set; } = String.Empty;
    }
   
}
