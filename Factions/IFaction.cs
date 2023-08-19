
using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Models;
using XZRPV.Vehicles;

namespace XZRPV.Factions
{
    public interface IFaction
    {
        int ID { get; }
        string Name { get; }
        Dictionary<int, string> Ranks { get; }
        bool IsLegal { get; }
        List<VehicleSystemData> Vehicles { get; }
        BlipFactionData BlipData { get; }
        string GetRankName(int rankId);
        bool IsPlayerLeader(User pUser);
        void SendFactionMessage(Player player, string message);
        void NotifyFactionMembers(string message);
        void BroadcastFactionMessage(string message);
    }
}
