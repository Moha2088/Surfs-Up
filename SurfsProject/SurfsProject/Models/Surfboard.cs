using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfsProject.Models
{
    public class Surfboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Length { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Width { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Thickness { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Volume { get; set; }
        public string Type { get; set; }
        public Decimal Price { get; set; }
        public string? Equipment { get; set; }

    }
}