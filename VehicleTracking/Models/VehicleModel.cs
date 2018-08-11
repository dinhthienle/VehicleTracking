using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.Models
{
    public class VehicleModel
    {
        public List<LandVehicle> LandVehicles { get; set; }
        public List<SeaVehicle> SeaVehicles { get; set; }
    }
}
