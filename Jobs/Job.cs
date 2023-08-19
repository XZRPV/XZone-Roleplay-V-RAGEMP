using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Factions;
using XZRPV.Vehicles;

namespace XZRPV.Jobs
{
    public class Job : Script, IJob
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<VehicleSystemData> Vehicles { get; set; }
        public BlipJobData BlipData { get; set; }

    }
}
