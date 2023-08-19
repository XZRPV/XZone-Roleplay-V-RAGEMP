using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Jobs.Woodcutter
{
    public class Woodcutter : Job
    {
        public Woodcutter()
        {
            ID = 5;
            Name = "Leñador";
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Faggio, new Vector3(0, 0, 0), 0f, 0, 0),
            };
            BlipData = new BlipJobData(
                BlipSprite: 858,
                BlipName: "Trabajo de " + Name,
                BlipPosition: new Vector3(478, -1159, 28)
            );

        }
    }
}
