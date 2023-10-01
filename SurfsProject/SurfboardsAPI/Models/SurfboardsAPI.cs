using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Linq;
using SurfsProject.API.SeedDataAPI.Models;
using System.Text.Json.Serialization;

namespace SeedDataAPI.Models
{

        public class SurfboardsAPI
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

            [Column(TypeName = "decimal(18, 2)")]
            public decimal Price { get; set; }

            public string? Equipment { get; set; }
            //[ForeignKey("dbo.AspNetUsers")]
           // public int? Rentee { get; set; }

            //[Timestamp]
            //public byte[] RowVersion { get; set; }

            public virtual List<SurfboardsAPI> Surfboards { get; set; }
           
        }
}

