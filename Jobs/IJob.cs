using System.Collections.Generic;
using XZRPV.Factions;
using XZRPV.Vehicles;

namespace XZRPV.Jobs
{
    public interface IJob
    {
        int ID { get; }
        string Name { get; }
        List<VehicleSystemData> Vehicles { get; }
        BlipJobData BlipData { get; }
    }
}
