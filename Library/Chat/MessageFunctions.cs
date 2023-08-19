using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace XZRPV.Library.Chat
{
    public class MessageFunctions : Script
    {
        public static void SendMessageToPlayersInRadiusColored(Player player, float radius, string message, string color, bool excludingSelf = true)
        {
            List<Player> playersNearby = NAPI.Player.GetPlayersInRadiusOfPlayer(radius, player);
            if (excludingSelf)
                playersNearby.RemoveAt(playersNearby.IndexOf(player));

            foreach (Player ply in playersNearby)
            {
                ply.SendChatMessage(color + message);
            }
        }
    }
}
