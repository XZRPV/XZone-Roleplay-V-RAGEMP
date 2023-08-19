using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Vehicles;

namespace XZRPV.Factions.FIB
{
    public class FIB : Faction
    {
        public const int AGENT = 1;
        public const int SENIOR_AGENT = 2;
        public const int SPECIAL_AGENT = 3;
        public const int SUPERVISORY_SPECIAL_AGENT = 4;
        public const int ASSISTANT_DIRECTOR = 5;

        public FIB()
        {
            ID = 3;
            Name = "FIB";
            Ranks = new Dictionary<int, string>()
            {
                { AGENT, "Agente" },
                { SENIOR_AGENT, "Agente Senior" },
                { SPECIAL_AGENT, "Agente Especial" },
                { SUPERVISORY_SPECIAL_AGENT, "Agente Especial Supervisorio" },
                { ASSISTANT_DIRECTOR, "Director Adjunto" }
            };
            IsLegal = true;
            Vehicles = new List<VehicleSystemData>()
            {
                new VehicleSystemData(VehicleHash.Fbi, new Vector3(111.446, -694.68, 32.762), 158.6943f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi, new Vector3(115.2916, -695.91, 32.761), 160.08109f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi, new Vector3(119.246, -697.46, 32.761), 160.6349f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi, new Vector3(122.888, -698.78, 32.761), 160.6028f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi, new Vector3(126.8548, -700.0849, 32.761), 159.97f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi, new Vector3(130.794, -701.545, 32.764), 159.377f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi, new Vector3(134.4766, -703.1, 32.7706), 161.7566f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi2, new Vector3(110.239, -714.13, 32.7556), 160.1033f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi2, new Vector3(114.072, -715.3908, 32.7556), 162.334f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi2, new Vector3(117.808, -716.7309, 32.7550), 161.2027f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi2, new Vector3(121.490, -718.463, 32.7556), 160.3680f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi2, new Vector3(125.3415, -719.7228, 32.7555), 159.1046f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi2, new Vector3(129.2014, -720.85, 32.7556), 160.8129f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi2, new Vector3(132.9329, -722.4823, 32.7558), 160.61543f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi2, new Vector3(136.637, -723.7087, 32.7553), 159.24698f, 0, 0),
                new VehicleSystemData(VehicleHash.Fbi2, new Vector3(140.535, -725.17, 32.755), 161.4303f, 0, 0),
                new VehicleSystemData(VehicleHash.Police4, new Vector3(95.9155, -729.12, 32.7394), -18.4890f, 0, 0),
                new VehicleSystemData(VehicleHash.Police4, new Vector3(99.90, -730.30, 32.7391), -20.1004f, 0, 0),
                new VehicleSystemData(VehicleHash.Police4, new Vector3(103.68, -731.9654, 32.7394), -20.2179f, 0, 0),
                new VehicleSystemData(VehicleHash.Police4, new Vector3(107.30, -733.250, 32.7394), -19.712f, 0, 0),
                new VehicleSystemData(VehicleHash.Policet, new Vector3(133.26, -741.745, 33.118), -18.99f, 0, 0),
                new VehicleSystemData(VehicleHash.Policet, new Vector3(136.822, -743.22, 33.117), -19.97f, 0, 0),
                new VehicleSystemData(VehicleHash.Policet, new Vector3(140.70, -744.61, 33.117), -19.69f, 0, 0),
                new VehicleSystemData(VehicleHash.Frogger, new Vector3(124.96817, -746.69055, 262.625), 157.34f, 0, 0),
                new VehicleSystemData(VehicleHash.Frogger, new Vector3(148.27477, -754.9253, 262.64114), -19.489f, 0, 0),
            };
        }
    }
}
