using System.ComponentModel.DataAnnotations;
using System;

namespace ParkyAPI.ModelViews.NationalParkViewModel
{
    public class NationalParkVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
