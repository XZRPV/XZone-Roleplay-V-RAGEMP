using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Factions.GrooveSt
{
    public class GrooveSt : Faction
    {
        public const int HOOD_RAT = 1;
        public const int LOW_TIME_G = 2;
        public const int SHOT_CALLER = 3;
        public const int OG = 4;
        public const int KINGPIN = 5;

        public GrooveSt()
        {
            ID = 7;
            Name = "Groove Street";
            Ranks = new Dictionary<int, string>()
            {
                { HOOD_RAT, "Hood Rat" },
                { LOW_TIME_G, "Low Time G" },
                { SHOT_CALLER, "Shot Caller" },
                { OG, "OG" },
                { KINGPIN, "Kingpin" }
            };
            IsLegal = false;
            
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Chino, new Vector3(83.988, -1929.7367, 20.1934), 43.66f, 125, 125),
                new VehicleSystemData(VehicleHash.Chino, new Vector3(89.17487, -1935.771, 20.199), 32.1898f, 125, 125),
                new VehicleSystemData(VehicleHash.Buccaneer, new Vector3(92.5602, -1942.4435, 20.0029), 24.1674f, 125, 125),
                new VehicleSystemData(VehicleHash.Buccaneer2, new Vector3(95.748, -1948.0941, 19.877), 36.6259f, 125, 125),
                new VehicleSystemData(VehicleHash.Chino2, new Vector3(101.0466, -1951.5778, 19.983), 75.1864f, 125, 125),
                new VehicleSystemData(VehicleHash.Faction, new Vector3(107.16754, -1951.8495, 20.133), 102.8611f, 125, 125),
                new VehicleSystemData(VehicleHash.Faction2, new Vector3(112.52311, -1948.9631, 20.02), 132.03f, 125, 125),
                new VehicleSystemData(VehicleHash.Faction3, new Vector3(116.27614, -1944.1295, 20.1505), 154.0318f, 125, 125),
                new VehicleSystemData(VehicleHash.Faction2, new Vector3(116.6510, -1938.1893, 20.01), -172.18211f, 125, 125),
                new VehicleSystemData(VehicleHash.Faction, new Vector3(114.1381, -1932.5857, 20.1529), -141.1987f, 125, 125),
                new VehicleSystemData(VehicleHash.Chino2, new Vector3(109.0443, -1928.6628, 20.049), -109.3013f, 125, 125),
                new VehicleSystemData(VehicleHash.Buccaneer2, new Vector3(103.14055, -1926.922, 19.888), -105.9187f, 125, 125),
                new VehicleSystemData(VehicleHash.Buccaneer, new Vector3(97.28185, -1924.9797, 20.03366), -112.1109f, 125, 125),
                new VehicleSystemData(VehicleHash.Chino, new Vector3(90.6625, -1920.9717, 20.140), -128.714f, 125, 125),
            };
        }
    }
}
