
using GTANetworkAPI;
using System.ComponentModel.DataAnnotations.Schema;

namespace XZRPV.Models
{
    public class House
    {
        public int HouseId { get; set; }
        public float EntranceX { get; set; }
        public float EntranceY { get; set; }
        public float EntranceZ { get; set; }
        public float ExitX { get; set; }
        public float ExitY { get; set; }
        public float ExitZ { get; set; }
        public decimal Price { get; set; }
        public int InteriorId { get; set; }
        public uint VirtualWorldId { get; set; }
        public bool IsLocked { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        [NotMapped]
        public Vector3 Entrance => new Vector3(EntranceX, EntranceY, EntranceZ);
        [NotMapped]
        public Vector3 Exit => new Vector3(ExitX, ExitY, ExitZ);

        [NotMapped]
        public Marker MarkerEntrance { get; set; }
        [NotMapped]
        public Marker MarkerExit { get; set; }
    }
}
