using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Factions.LaCosaNostra
{
    public class LaCosaNostra : Faction
    {
        public const int SOLDATO = 1;
        public const int CAPORALO = 2;
        public const int SOTTOTENENTE = 3;
        public const int CONSIGLIERE = 4;
        public const int DON = 5;

        public LaCosaNostra()
        {
            ID = 5;
            Name = "La Cosa Nostra";
            Ranks = new Dictionary<int, string>()
            {
                { SOLDATO, "Soldato" },
                { CAPORALO, "Caporalo" },
                { SOTTOTENENTE, "Sottotenente" },
                { CONSIGLIERE, "Consigliere" },
                { DON, "Don" }
            };
            IsLegal = false;
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Btype, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Btype3, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Ztype, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Peyote, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Peyote, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Baller4, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Baller4, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Schafter4, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Schafter4, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Schafter4, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Schafter4, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Dynasty, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Dynasty, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Dynasty, new Vector3(0, 0, 0), 0f, 0, 0),
                new VehicleSystemData(VehicleHash.Swift2, new Vector3(0, 0, 0), 0f, 0, 0),
            };
        }
    }
}
