using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Models
{
    [Index(nameof(City), Name = "IX_IBGE_City")]
    [Index(nameof(State), Name = "IX_IBGE_State")]
    public class Ibge
    {
        [Key]
        [MaxLength(7)]
        public string? Id { get; set; }

        [MaxLength(2)]
        public string? State { get; set; }

        [MaxLength(80)]
        public string? City { get; set; }
    }
}