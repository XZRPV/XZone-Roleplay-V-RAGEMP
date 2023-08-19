using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Factions.Ballas
{
    public class Ballas : Faction
    {
        public const int BUCKS_BABY_GANGSTA = 1;
        public const int SOLDIER = 2;
        public const int SHOT_CALLER = 3;
        public const int OG = 4;
        public const int KINGPIN = 5;

        public Ballas()
        {
            ID = 8;
            Name = "Ballas";
            Ranks = new Dictionary<int, string>()
            {
                { BUCKS_BABY_GANGSTA, "Bucks Baby Gangsta" },
                { SOLDIER, "Soldier" },
                { SHOT_CALLER, "Shot Caller" },
                { OG, "OG" },
                { KINGPIN, "Kingpin" }
            };
            IsLegal = false;
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Chino, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Chino, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Buccaneer, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Buccaneer2, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Chino2, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Faction, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Faction2, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Faction3, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Faction2, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Faction, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Chino2, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Buccaneer2, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Buccaneer, new Vector3(0, 0, 0), 0f, 145, 145),
                new VehicleSystemData(VehicleHash.Chino, new Vector3(0, 0, 0), 0f, 145, 145),
            };
        }
    }
}
