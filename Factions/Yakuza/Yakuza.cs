using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Factions.Yakuza
{
    public class Yakuza : Faction
    {
        public const int GUMI = 1;
        public const int KUMICHO = 2;
        public const int WAKAGASHIRA = 3;
        public const int SAIROKU = 4;
        public const int OYABUN = 5;

        public Yakuza()
        {
            ID = 6;
            Name = "Yakuza";
            Ranks = new Dictionary<int, string>()
            {
                { GUMI, "Gumi" },
                { KUMICHO, "Kumichō" },
                { WAKAGASHIRA, "Wakagashira" },
                { SAIROKU, "Sairōku" },
                { OYABUN, "Oyabun" }
            };
            IsLegal = false;
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Cogcabrio, new Vector3(-1463.69, -42.30, 53.93), -50.91f, 0, 0),
                new VehicleSystemData(VehicleHash.Schwarzer, new Vector3(-1464.32, -20.54, 54.09), 50.08f, 0, 0),
                new VehicleSystemData(VehicleHash.Schwarzer, new Vector3(-1469.73, -24.53, 53.94), 42.29f, 0, 0),
                new VehicleSystemData(VehicleHash.Baller4, new Vector3(-1465.50, -28.33, 54.58), 50.12f, 0, 0),
                new VehicleSystemData(VehicleHash.Baller4, new Vector3(-1459.60, -24.78, 54.57), 51.96f, 0, 0),
                new VehicleSystemData(VehicleHash.Schafter4, new Vector3(-1454.01, -25.89, 54.18), 158.29f, 0, 0),
                new VehicleSystemData(VehicleHash.Schafter4, new Vector3(-1453.85, -39.68, 54.20), 50.03f, 0, 0),
                new VehicleSystemData(VehicleHash.Schafter4, new Vector3(-1455.39, -43.17, 54.25), 43.13f, 0, 0),
                new VehicleSystemData(VehicleHash.Double, new Vector3(-1466.95, -16.31, 54.15), 24.23f, 0, 0),
                new VehicleSystemData(VehicleHash.Double, new Vector3(-1473.93, -19.93, 54.18), 34.05f, 0, 0),
                new VehicleSystemData(VehicleHash.Bati, new Vector3(-1463.4, -38.65, 53.99), -49.80f, 0, 0),
                new VehicleSystemData(VehicleHash.Bati, new Vector3(-1460.547, -42.07096, 54.03688), -49.856976f, 0, 0),
                new VehicleSystemData(VehicleHash.Swift2, new Vector3(-1482.9695, -26.62577, 62.92004), 129.48637f, 0, 0),
            };
        }
    }
}
