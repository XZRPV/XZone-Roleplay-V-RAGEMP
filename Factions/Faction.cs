using GTANetworkAPI;
using System.Collections.Generic;
using System.Text;
using XZRPV.Library;
using XZRPV.Library.Chat;
using XZRPV.Library.Extensions;
using XZRPV.Models;
using XZRPV.Vehicles;

namespace XZRPV.Factions
{
    public class Faction : Script, IFaction
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Dictionary<int, string> Ranks { get; set; }
        public bool IsLegal { get; set; }
        public List<VehicleSystemData> Vehicles { get; set; }
        public BlipFactionData BlipData { get; set; }

        public string GetRankName(int rankId)
        {
            if (Ranks[rankId] == null)
            {
                return "N/A";
            }

            return Ranks[rankId];
        }

        public bool IsPlayerLeader(User pUser)
        {
            return pUser.FactionId == ID && pUser.FactionRankId == Ranks.Count;
        }
        public void SendFactionMessage(Player player, string message)
        {
            IFaction faction = FactionManager.GetFactionByID(ID);
            string playerRankName = GetRankName(player.GetUserData().FactionRankId);

            string formattedMessage = new StringBuilder()
                .Append(ChatColors.FACTION_CHAT_COLOR)
                .Append($"[{faction.Name} - {playerRankName}] ")
                .Append($"{player.Name}: {ChatColors.WHITE_COLOR} {message}")
                .ToString();

            BroadcastFactionMessage(formattedMessage);
        }

        public void NotifyFactionMembers(string message)
        {
            IFaction faction = FactionManager.GetFactionByID(ID);

            string formattedMessage = new StringBuilder()
               .Append(ChatColors.FACTION_CHAT_COLOR)
               .Append($"[{faction.Name}] ")
               .Append($"{ChatColors.WHITE_COLOR} {message}")
               .ToString();

            BroadcastFactionMessage(formattedMessage);
        }

        public void BroadcastFactionMessage(string message)
        {
            IFaction faction = FactionManager.GetFactionByID(ID);

            if (faction == null)
            {
                return;
            }

            foreach (Player player in PlayerHandler.GetPlayerList())
            {
                User pUser = player.GetUserData();

                if (pUser.FactionId == ID)
                {
                    player.SendChatMessage(message);
                }
            }
        }
    }
}
