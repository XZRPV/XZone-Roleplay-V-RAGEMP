using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Factions;
using XZRPV.Vehicles;

namespace XZRPV.Jobs.Trucker
{
    public class Trucker : Job
    {
        public Trucker()
        {
            ID = 1;
            Name = "Camionero";
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Tiptruck, new Vector3(485.00, -1157.22, 28.89), -94.56f, 0, 0),
                new VehicleSystemData(VehicleHash.Tiptruck2, new Vector3(467.09, -1152.03, 28.89), 87.36f, 0, 0),
            };
            BlipData = new BlipJobData(
                BlipSprite: 67,
                BlipName: "Trabajo de " + Name,
                BlipPosition: new Vector3(478, -1159, 28)
            );
        }
    }
}
