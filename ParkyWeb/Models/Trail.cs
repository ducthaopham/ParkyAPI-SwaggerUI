using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkyWeb.Models
{
    public class Trail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        public int? NationalParkId { get; set; }
        [ForeignKey("NationalParkId")]
        public NationalPark NationalPark { get; set; }
    }
}
