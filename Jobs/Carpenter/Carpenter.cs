using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Jobs.Carpenter
{
    public class Carpenter : Job
    {
        public Carpenter()
        {
            ID = 6;
            Name = "Carpintero";
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Faggio, new Vector3(0, 0, 0), 0f, 0, 0),
            };
            BlipData = new BlipJobData(
                BlipSprite: 842,
                BlipName: "Trabajo de " + Name,
                BlipPosition: new Vector3(478, -1159, 28)
            );
        }
    }
}
