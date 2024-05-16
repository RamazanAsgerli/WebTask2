using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Team:BaseEntity
    {
        [Required]
        [StringLength(15)]
        public string Name { get; set; } = null!;

        [StringLength(15)]
        public string Title { get; set; } = null!;

        public string? ImgUrl { get; set; } = null!;
        [NotMapped]
        public IFormFile PhotoFile { get; set; } = null!;
    }
}
