using System.ComponentModel.DataAnnotations;

namespace ParkyWeb.Models
{
    public class Trail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Distance { get; set; }
        public int NationalParkId { get; set; }
    }
}
