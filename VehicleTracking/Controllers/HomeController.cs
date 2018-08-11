using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Models;

namespace VehicleTracking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(List<Vehicle> lst)
        {
            var isAuthorized = IsAutthorized("fake", "fake");
            var vehicles = Enumerable.Empty<Vehicle>();
            var model = new VehicleModel();
            if (isAuthorized)
            {
                vehicles = GetUserVehicles();
                model.LandVehicles = vehicles.OfType<LandVehicle>().ToList();
                model.SeaVehicles = vehicles.OfType<SeaVehicle>().ToList();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveLandVehicles(VehicleModel model)
        {
            // Run debug to see model binding of Feul and nested binding of Tire Status: BindingValue
            var bindingList = model.LandVehicles;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveSeaVehicles(VehicleModel model)
        {
            // Run debug to see the model binding
            var bindingList = model.SeaVehicles;
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// This to faking user authorization
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool IsAutthorized(string username, string password)
        {
            return true;
        }

        /// <summary>
        /// This should be in vehicle service
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Vehicle> GetUserVehicles()
        {
            return new List<Vehicle>
            {
                new LandVehicle
                {
                    Name = "Car",
                    Fuel = 100,
                    Tires = GenerateTires(TireType.Car, TireStatus.Good)
                },
                 new LandVehicle
                {
                    Name = "Truck",
                    Fuel = 100,
                    Tires = GenerateTires(TireType.Truck, TireStatus.Good)
                },
                  new LandVehicle
                {
                    Name = "Motor",
                    Fuel = 100,
                    Tires = GenerateTires(TireType.Motor, TireStatus.Good)
                },
                    new SeaVehicle
                {
                    Name = "Boat",
                    Fuel = 100,
                }
            };
        }

        /// <summary>
        /// this should be in vehicle service
        /// </summary>
        /// <returns></returns>
        private List<Tire> GenerateTires(TireType tireType, TireStatus tireStatus)
        {
            int numberOfTires = 4;
            var tires = new List<Tire>();

            if (tireType == TireType.Motor)
            {
                numberOfTires = 2;
            }
            else if (tireType == TireType.Truck)
            {
                numberOfTires = 6;
            }

            for (int i = 1; i <= numberOfTires; i++)
            {
                tires.Add(new Tire
                {
                    Name = "Tire " + i,
                    Status = tireStatus,
                    SelectedStatus = (int)tireStatus,
                    Type = tireType
                }
                 );
            }

            return tires;
        }
    }
}
