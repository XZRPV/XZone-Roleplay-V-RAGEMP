using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Jobs.Fisherman
{
    public class Fisherman : Job
    {
        public Fisherman()
        {
            ID = 2;
            Name = "Pescador";
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Faggio, new Vector3(0, 0, 0), 0f, 0, 0),
            };
            BlipData = new BlipJobData(
                BlipSprite: 68,
                BlipName: "Trabajo de " + Name,
                BlipPosition: new Vector3(478, -1159, 28)
            );
        }
    }
}
