using GTANetworkAPI;

namespace XZRPV.Jobs
{
    public class BlipJobData
    {
        public BlipJobData(uint BlipSprite, string BlipName, Vector3 BlipPosition)
        {
            this.BlipSprite = BlipSprite;
            this.BlipName = BlipName;
            this.BlipPosition = BlipPosition;
        }

        public uint BlipSprite { get; set; }
        public string BlipName { get; set; }
        public Vector3 BlipPosition { get; set; }
    }
}
