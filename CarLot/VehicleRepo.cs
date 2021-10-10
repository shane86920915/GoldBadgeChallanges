using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLot
{
   public class VehicleRepo
    {
        private readonly List<Vehicles> _vehicleContent = new List<Vehicles>();
       
        
        //create
        public void AddvehicleToList(Vehicles vehicleitem)
        {
            _vehicleContent.Add(vehicleitem);
        }

        public List<Vehicles> GetVehicleList()
        {
            return _vehicleContent;
        }



        //update
        public bool UpdateVehicle(int originalId, Vehicles NewVehicle)
        {
            Vehicles OldVehicle = GetVehicleByID(originalId);
            if (OldVehicle != null)
            {
                OldVehicle.VehicleID = NewVehicle.VehicleID;
                OldVehicle.VehicleMake = NewVehicle.VehicleMake;
                OldVehicle.VehicleModel = NewVehicle.VehicleModel;
                OldVehicle.VehicleColor = NewVehicle.VehicleColor;
                OldVehicle.ListOfVehickles = NewVehicle.ListOfVehickles;
                OldVehicle.VehiclePrice = NewVehicle.VehiclePrice;
                OldVehicle.VehicleTypes = NewVehicle.VehicleTypes;
                OldVehicle.NewOrUsed = NewVehicle.NewOrUsed;
                OldVehicle.VehicleMileage = NewVehicle.VehicleMileage;
                return true;
            }
            else
            {
                return false;
            }
        }






        //delete
        public bool RemoveVehicle(int VehicleID)
        {
            Vehicles vehicleItem = GetVehicleByID(VehicleID);
            if (VehicleID > 0)
            {
                return false;
            }
            int initialcount = _vehicleContent.Count;
            _vehicleContent.Remove(vehicleItem);
            if(initialcount > _vehicleContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
        //helper
        public Vehicles GetVehicleByID(int VehicleID)
        {
            foreach (Vehicles vehicles in _vehicleContent)
            {
                if (vehicles.VehicleID == VehicleID)
                {
                    return vehicles;

                }
            }
                Console.WriteLine("There is no vehicle with that ID");
                return null;
        }




    }
}
