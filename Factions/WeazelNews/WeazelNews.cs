using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Factions.WeazelNews
{
    public class WeazelNews : Faction
    {
        public const int REPORTER = 1;
        public const int SENIOR_REPORTER = 2;
        public const int CORRESPONDENT = 3;
        public const int ANCHOR = 4;
        public const int EXECUTIVE_PRODUCER = 5;

        public WeazelNews()
        {
            ID = 4;
            Name = "Weazel News";
            Ranks = new Dictionary<int, string>()
            {
                { REPORTER, "Reportero" }, 
                { SENIOR_REPORTER, "Reportero Senior" },
                { CORRESPONDENT, "Corresponsal" },
                { ANCHOR, "Presentador" },
                { EXECUTIVE_PRODUCER, "Productor Ejecutivo" }
            };
            IsLegal = true;
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Rumpo, new Vector3(-616.142, -920.149, 23.4622), 109.75164f, 111, 111),
                new VehicleSystemData(VehicleHash.Rumpo, new Vector3(-616.105, -916.306, 23.753), 108.732f, 111, 111),
                new VehicleSystemData(VehicleHash.Rumpo, new Vector3(-616.1049, -911.8987, 24.0443), 109.1217f, 111, 111),
                new VehicleSystemData(VehicleHash.Hellion, new Vector3(-557.5027, -925.0557, 23.4928), -87.940f, 111, 111),
                new VehicleSystemData(VehicleHash.Hellion, new Vector3(-558.0986, -929.4143, 23.4943), -88.652f, 111, 111),
                new VehicleSystemData(VehicleHash.Hellion, new Vector3(-557.9517, -933.33, 23.4851), -88.717995f, 111, 111),
                new VehicleSystemData(VehicleHash.Hellion, new Vector3(-557.6168, -937.63, 23.4812), -90.123f, 111, 111),
                new VehicleSystemData(VehicleHash.Tourbus, new Vector3(-532.5212, -890.8433, 24.45), -178.108f, 0, 0),
                new VehicleSystemData(VehicleHash.Stretch, new Vector3(-558.3, -890.180, 24.68), 176.569f, 111, 111),
                new VehicleSystemData(VehicleHash.Patriot2, new Vector3(-565.447, -889.6, 24.77), 179.662f, 111, 111),
                new VehicleSystemData(VehicleHash.Maverick, new Vector3(-583.178, -930.5559, 36.9395), 88.9729f, 111, 111),
            };
        }
    }
}
