using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLot
{
    public enum VehicleType
    {
        Car = 1,
        Truck,
        Jeep
    }
    public class Vehicles
    {
       
        public int VehicleID { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
       
        public string VehicleColor { get; set; }
        public decimal VehiclePrice { get; set; }
        public List<string> ListOfVehickles { get; set; } = new List<string>();
        public VehicleType VehicleTypes { get; set; }
        public bool NewOrUsed { get; set; }
        public double VehicleMileage { get; set; }

        public Vehicles()
        {

        }
        public Vehicles (int vehicleid, string vehiclemake, string vehiclemodel, string vehiclecolor, decimal vehicleprice,
            VehicleType vehicletypes, bool neworused, double vehiclemileage)
        {
            VehicleID = vehicleid;
            VehicleMake = vehiclemake;
            VehicleModel = vehiclemodel;
            VehicleColor = vehiclecolor;
            VehiclePrice = vehicleprice;
            VehicleTypes = vehicletypes;
            NewOrUsed = neworused;
            VehicleMileage = vehiclemileage;

        }
    }
    
}
