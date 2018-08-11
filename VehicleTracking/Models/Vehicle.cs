using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.Models
{
    public class Vehicle
    {
        public string Name { get; set; }
        public int Fuel { get; set; }
    }
    
    public class LandVehicle: Vehicle
    {        
        public List<Tire> Tires { get; set; }
    }
    
    public class SeaVehicle: Vehicle { }
    
    public class Tire
    {
        public string Name { get; set; }
        public int SelectedStatus { get; set; }
        public string BindingValue { get; set; } // This property to bind value when user submit (nested binding)
        public TireStatus Status { get; set; }
        public TireType Type { get; set; }
    }
}
