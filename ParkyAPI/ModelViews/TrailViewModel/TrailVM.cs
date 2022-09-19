using ParkyAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkyAPI.ModelViews.TrailViewModel
{
    public class TrailVM
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Distance { get; set; }
        public int NationalParkId { get; set; }

    }
}
