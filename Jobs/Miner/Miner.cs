using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Jobs.Miner
{
    public class Miner : Job
    {
        public Miner()
        {
            ID = 4;
            Name = "Minero";
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Faggio, new Vector3(0, 0, 0), 0f, 0, 0),
            };
            BlipData = new BlipJobData(
                BlipSprite: 527,
                BlipName: "Trabajo de " + Name,
                BlipPosition: new Vector3(478, -1159, 28)
            );
        }
    }
}
