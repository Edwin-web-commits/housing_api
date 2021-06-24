﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class PropertyDetailDTO:PropertyListDTO
    {
        public int CarpetArea { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Description { get; set; }
        public int FloorNo { get; set; }
        public int TotalFloor { get; set; }
        public int Bathrooms { get; set; }
        public string MainEntrance { get; set; }
        public bool Gated { get; set; }
        public int Security { get; set; }
        public int Maintanance { get; set; }
        public int Age { get; set; }
    }
}
