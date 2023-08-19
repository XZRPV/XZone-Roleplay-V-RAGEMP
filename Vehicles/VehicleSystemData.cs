using GTANetworkAPI;

namespace XZRPV.Vehicles
{
    public class VehicleSystemData
    {
        public VehicleHash VehicleHash { get; set; }
        public Vector3 Position { get; set; }
        public float RotationZ { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }

        public VehicleSystemData(VehicleHash vehicleHash, Vector3 position, float rotationZ, int color1, int color2)
        {
            VehicleHash = vehicleHash;
            Position = position;
            RotationZ = rotationZ;
            Color1 = color1;
            Color2 = color2;
        }
    }
}
