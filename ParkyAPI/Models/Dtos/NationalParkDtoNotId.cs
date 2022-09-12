using System.ComponentModel.DataAnnotations;
using System;

namespace ParkyAPI.Models.Dtos
{
    public class NationalParkDtoNotId
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
