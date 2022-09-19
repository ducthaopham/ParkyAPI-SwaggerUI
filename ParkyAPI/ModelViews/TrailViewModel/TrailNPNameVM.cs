using System.ComponentModel.DataAnnotations;
using System;
using ParkyAPI.ModelViews.NationalParkViewModel;

namespace ParkyAPI.ModelViews.TrailViewModel
{
    public class NationalParkVM1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TrailNPNameVM 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Distance { get; set; }
        public NationalParkVM1 NationalPark { get; set; }
    }
}
