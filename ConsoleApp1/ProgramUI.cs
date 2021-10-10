using CarLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLot2
{
    class ProgramUI
    {
        private readonly VehicleRepo _vehicleRepo = new VehicleRepo();



        public void Run()
        {
            Vehicles();
            SeedVehicleList();
        }
        private void Vehicles()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select a menu option\n" +
                    "1. Create a new vehicle \n" +
                    "2. Display all vehicles \n" +
                    "3. Update an existing vehicle \n" +
                    "4. Delete an existing vehicle \n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateNewVehicle();
                        break;
                    case "2":
                        DisplayAllVehicles();
                        break;
                    case "3":
                        UpdateAnExistingvehicle();
                        break;
                    case "4":
                        DeleteAnExistingvehicle();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid vehicle number.");
                        break;

                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewVehicle()
        {
            Console.Clear();
            Vehicles newvehicle = new Vehicles();

            Console.WriteLine("Enter the vehicle id number.");

            string vehicleIdNumberAsString = Console.ReadLine();
            int vehicleIdNumberAsInt = int.Parse(vehicleIdNumberAsString);
            newvehicle.VehicleID = vehicleIdNumberAsInt;

            Console.WriteLine("Enter the vehicle make.");
            newvehicle.VehicleMake = Console.ReadLine();

            Console.WriteLine("Enter the vehicle model.");
            newvehicle.VehicleModel = Console.ReadLine();

            Console.WriteLine("Enter the color of the vehicle.");
            newvehicle.VehicleColor = Console.ReadLine();

            Console.WriteLine("Enter the price of the vehicle.");

            string priceAsString = Console.ReadLine();
            int priceAsDecimal = int.Parse(priceAsString);
            newvehicle.VehiclePrice = priceAsDecimal;

            bool carPotitionfilled = false;
            while (!carPotitionfilled)
            {
                Console.WriteLine("Please input a vehicle name.");
                var vehicle = Console.ReadLine();

                Console.WriteLine("Do you want to add another vehicle? y/n");
                var userInput = Console.ReadLine();

                if (userInput == "y" || userInput == "Y")
                {

                    newvehicle.ListOfVehickles.Add(vehicle);
                }

                else if (userInput == "n"|| userInput == "N")
                {
                    carPotitionfilled = true;
                    newvehicle.ListOfVehickles.Add(vehicle);
                }

            }

            newvehicle.VehicleTypes = SelectVechicleType();
            newvehicle.NewOrUsed = IsNewOrUsed();

            Console.WriteLine("Please enter the mileage of the vehicle");

            string mileageAsString = Console.ReadLine();
            int mileageAsDouble = int.Parse(mileageAsString);
            newvehicle.VehicleMileage = mileageAsDouble;
        }

      
        private void viewVehicleData(Vehicles vehicle)
        {
            Console.WriteLine($"{vehicle.VehicleID}\n" +
                $"{vehicle.VehicleMake}");
          
            foreach (var v in vehicle.ListOfVehickles)
            {
                Console.WriteLine(v);
            }
        }

        private void DisplayAllVehicles()
        {
            Console.Clear();
            List<Vehicles> listOfVehicles = _vehicleRepo.GetVehicleList();
            Console.WriteLine("Display all vehicles");

            foreach (Vehicles vehicleItem in listOfVehicles)
            {
                DisplayVehicleDetails(vehicleItem);
            }
            Console.WriteLine("\n");
        }
        private void DisplayVehicleDetails(Vehicles vehicleItem)
        {
            Console.WriteLine($"VehicleId:{vehicleItem.VehicleID}\n" +
                $"VehicleMake:{vehicleItem.VehicleMake}\n" +
                $"VehicleModel:{vehicleItem.VehicleModel}\n" +
                $"VehicleColor:{vehicleItem.VehicleColor}\n" +
                $"VehiclePrice:{vehicleItem.VehiclePrice}\n" +
                $"VehicleType: {vehicleItem.VehicleTypes}\n" +
                $"NewOrUsed: {vehicleItem.NewOrUsed}\n" +
                $"VehicleMileage: {vehicleItem.VehicleModel}\n");

            Console.WriteLine("***************OverView******************");
            foreach (var detail in vehicleItem.ListOfVehickles)
            {
                Console.WriteLine($"detail: {detail}");
            }
            Console.WriteLine("********************************");
        }

        private void UpdateAnExistingvehicle()
        {

        }

        private void DeleteAnExistingvehicle()
        {

        }


        private VehicleType SelectVechicleType()
        {
            Console.WriteLine("Please select a vechicle type\n" +
                               "1.Car\n" +
                               "2.Truck\n" +
                               "3.Jeep\n");

            int userInputType = int.Parse(Console.ReadLine());
            VehicleType type = (VehicleType)userInputType;
            return type;
        }

        private bool IsNewOrUsed()
        {
            Console.WriteLine("Is this car NEW ? y/n");
            var userInput = Console.ReadLine();

            if (userInput == "y" || userInput == "Y")
            {

                return true;
            }
            return false;

        }

        private void SeedVehicleList()
        {
           Vehicles SubaruImpreza = new Vehicles(1, "Subaru", "Sedan", "red", 19000.00m, VehicleType.Car, true, 0 );
            Vehicles FordFlex = new Vehicles(2, "Ford", "Flex", "white", 21230.00m, VehicleType.Truck, false, 72000);
            Vehicles Hondiaccent = new Vehicles(3, "Hondia", "accent", "black", 8000, VehicleType.Car, false, 91000);
            _vehicleRepo.AddvehicleToList(SubaruImpreza);
            _vehicleRepo.AddvehicleToList(FordFlex);
            _vehicleRepo.AddvehicleToList(Hondiaccent);
        }

    }
}
