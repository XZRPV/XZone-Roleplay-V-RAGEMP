using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Jobs.Trashman
{
    public class Trashman : Job
    {
        public Trashman()
        {
            ID = 7;
            Name = "Basurero";
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Faggio, new Vector3(0, 0, 0), 0f, 0, 0),
            };
            BlipData = new BlipJobData(
                BlipSprite: 318,
                BlipName: "Trabajo de " + Name,
                BlipPosition: new Vector3(478, -1159, 28)
            );
        }
    }
}
