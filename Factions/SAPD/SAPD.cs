using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Factions.SAPD
{
    public class SAPD : Faction
    {
        public const int CADET = 1;
        public const int OFFICER = 2;
        public const int SERGEANT = 3;
        public const int LIEUTENANT = 4;
        public const int CAPTAIN = 5;

        public SAPD()
        {
            ID = 1;
            Name = "SAPD";
            Ranks = new Dictionary<int, string>()
            {
                { CADET, "Cadete" },
                { OFFICER, "Oficial" },
                { SERGEANT, "Sargento" },
                { LIEUTENANT, "Teniente" },
                { CAPTAIN, "Capitan" }
            };
            IsLegal = true;
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Police, new Vector3(408.67, -985.00, 28.87), 49.59f, 111, 0),
                new VehicleSystemData(VehicleHash.Police, new Vector3(408.60, -989.33, 28.87), 53.78f, 111, 0),
                new VehicleSystemData(VehicleHash.Police, new Vector3(408.68, -980.77, 28.87), 49.90f, 111, 0),
                new VehicleSystemData(VehicleHash.Police, new Vector3(408.71, -993.85, 28.87), 52.60f, 111, 0),
                new VehicleSystemData(VehicleHash.Police, new Vector3(408.71, -998.55, 28.87), 50.51f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(406.27, -1000.91, 28.73), 119.21f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(406.96, -1002.13, 28.74), 120.44f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(406.23, -1004.04, 28.74), 120.26f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(408.49, -1002.76, 28.74), 121.81f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(406.41, -1005.37, 28.74), 121.14f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(409.24, -1003.65, 28.74), 121.11f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(406.36, -1006.95, 28.74), 118.38f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(409.12, -1005.42, 28.74), 118.58f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(409.16, -1007.22, 28.74), 125.08f, 111, 0),
                new VehicleSystemData(VehicleHash.Policeb, new Vector3(406.28, -1009.24, 28.74), 122.92f, 111, 0),
                new VehicleSystemData(VehicleHash.Police4, new Vector3(463.53, -1019.93, 27.70), 86.81f, 0, 0),
                new VehicleSystemData(VehicleHash.Police4, new Vector3(463.39, -1014.75, 27.69), 90.38f, 0, 0),
                new VehicleSystemData(VehicleHash.Police3, new Vector3(431.32, -996.50, 25.52), 178.58f, 111, 0),
                new VehicleSystemData(VehicleHash.Police3, new Vector3(436.29, -996.52, 25.52), -178.58f, 111, 0),
                new VehicleSystemData(VehicleHash.Policet, new Vector3(452.38, -997.07, 25.74), -179.62f, 111, 0),
                new VehicleSystemData(VehicleHash.Policet, new Vector3(447.39, -996.77, 25.75), -179.58f, 111, 0),
                new VehicleSystemData(VehicleHash.Police2, new Vector3(427.43, -1028.18, 28.60), 4.57f, 111, 0),
                new VehicleSystemData(VehicleHash.Police2, new Vector3(431.428, -1027.80, 28.53), 3.45f, 111, 0),
                new VehicleSystemData(VehicleHash.Police2, new Vector3(434.93, -1027.64, 28.46), 3.99f, 111, 0),
                new VehicleSystemData(VehicleHash.Police2, new Vector3(438.65, -1027.20, 28.40), 5.98f, 111, 0),
                new VehicleSystemData(VehicleHash.Police2, new Vector3(442.49, -1026.96, 28.33), 4.61f, 111, 0),
                new VehicleSystemData(VehicleHash.Police2, new Vector3(446.24, -1026.47, 28.25), 5.18f, 111, 0),
                new VehicleSystemData(VehicleHash.Polmav, new Vector3(449.64, -981.35, 44.07), 90.30f, 0, 111),
                new VehicleSystemData(VehicleHash.Polmav, new Vector3(481.65, -982.12, 41.39), -88.85f, 0, 111),
                new VehicleSystemData(VehicleHash.Pbus, new Vector3(471.73, -1024.37, 28.43), -86.58f, 80, 111),
            };
            BlipData = new BlipFactionData(
                BlipSprite: 60,
                BlipName: "SAPD",
                BlipPosition: new Vector3(432, -981, 30)
            );
        }
    }
}
