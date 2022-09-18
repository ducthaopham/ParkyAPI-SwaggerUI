using System;

namespace ParkyAPI.ModelViews.NationalParkViewModel
{
    public class NationalParkCreateVM
    {
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
