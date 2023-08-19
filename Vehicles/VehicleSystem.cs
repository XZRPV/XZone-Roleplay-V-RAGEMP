using GTANetworkAPI;
using System.Collections.Generic;

namespace XZRPV.Vehicles
{
    public class VehicleSystem : Script
    {
        private static Dictionary<Vehicle, VehicleSystemData> Vehicles = new Dictionary<Vehicle, VehicleSystemData>();

        public static void AddVehicle(Vehicle vehicle, VehicleSystemData vehicleData)
        {
            Vehicles[vehicle] = vehicleData;
            vehicle.SetData("VehicleData", vehicleData);
        }

        public static VehicleSystemData GetVehicleData(Vehicle vehicle)
        {
            return vehicle.GetData<VehicleSystemData>("VehicleData");
        }

        public static void SetVehicleJobId(Vehicle vehicle, string jobId)
        {
            vehicle.SetData("JobId", jobId);
        }

        public static void SetVehicleFactionId(Vehicle vehicle, string factionId)
        {
            vehicle.SetData("FactionId", factionId);
        }

        public static string GetVehicleJobId(Vehicle vehicle)
        {
            return vehicle.GetData<string>("JobId");
        }

        public static string GetVehicleFactionId(Vehicle vehicle)
        {
            return vehicle.GetData<string>("FactionId");
        }
    }
}
