using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Factions.SAMD
{
    public class SAMD : Faction
    {
        public const int TRAINEE = 1;
        public const int PARAMEDIC = 2;
        public const int SENIOR_PARAMEDIC = 3;
        public const int CHIEF_PARAMEDIC = 4;
        public const int MEDICAL_DIRECTOR = 5;

        public SAMD()
        {
            ID = 2;
            Name = "SAMD";
            Ranks = new Dictionary<int, string>()
            {
                { TRAINEE, "Aprendiz" },
                { PARAMEDIC, "Paramédico" },
                { SENIOR_PARAMEDIC, "Paramédico Senior" },
                { CHIEF_PARAMEDIC, "Jefe de Paramédicos" },
                { MEDICAL_DIRECTOR, "Director Médico" }
            };
            IsLegal = true;
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Ambulance, new Vector3(294.52753, -610.6071, 43.15063), 70.0948f, 0, 0),
                new VehicleSystemData(VehicleHash.Ambulance, new Vector3(295.68, -607.3776, 43.1232), 68.2861f, 0, 0),
                new VehicleSystemData(VehicleHash.Ambulance, new Vector3(296.7799, -604.322, 43.1066), 70.1664f, 0, 0),
                new VehicleSystemData(VehicleHash.Ambulance, new Vector3(289.14273, -584.35394, 42.9134), -18.841375f, 0, 0),
                new VehicleSystemData(VehicleHash.Ambulance, new Vector3(285.2733, -594.98, 42.8978), 159.1525f, 0, 0),
                new VehicleSystemData(VehicleHash.Ambulance, new Vector3(289.7145, -614.9302, 43.20009), -20.30f, 0, 0),
                new VehicleSystemData(VehicleHash.Ambulance, new Vector3(285.5460, -613.444, 43.1592), -20.0671f, 0, 0),
                new VehicleSystemData(VehicleHash.Ambulance, new Vector3(281.68677, -612.0132, 43.0525), -18.865f, 0, 0),
            };
        }
    }
}
