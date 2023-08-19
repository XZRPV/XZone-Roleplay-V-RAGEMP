using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using XZRPV.Library;

namespace XZRPV.Admin
{
    public class AdminJailSystem : Script
    {
        private Dictionary<int, AdminJailPlayerData> jailedPlayers = new Dictionary<int, AdminJailPlayerData>();
        private Vector3 jailCellPosition = new Vector3(-416.381, 1129.07, 325.905);
        private readonly Timer saveTimer;

        public AdminJailSystem()
        {
            jailedPlayers = new Dictionary<int, AdminJailPlayerData>();

            saveTimer = new Timer
            {
                Interval = 10_000 
            };
            saveTimer.Elapsed += OnJailTimeElapsed;
            saveTimer.Start();
        }

        public void OnJailTimeElapsed(object sender, ElapsedEventArgs e)
        {
            NAPI.Task.Run(() =>
            {
                DateTime currentTime = DateTime.UtcNow;

                foreach (var jailedPlayerData in jailedPlayers.Values)
                {

                    if (currentTime.Ticks >= jailedPlayerData.JailReleaseTime.Ticks)
                    {
                        int targetPlayerId = jailedPlayers.FirstOrDefault(x => x.Value == jailedPlayerData).Key;
                        Player targetPlayer = PlayerHandler.GetPlayer(targetPlayerId);

                        targetPlayer.Position = jailedPlayerData.OriginalPosition;
                        jailedPlayers.Remove(targetPlayerId);

                        targetPlayer.SendChatMessage("Has sido liberado de la cárcel.");
                    }
                }
            });
        }

        public void JailPlayer(Player player, string reason, DateTime jailTime)
        {
            int playerID = PlayerHandler.GetIDFromPlayer(player);

            if (jailedPlayers.ContainsKey(playerID))
            {
                player.SendChatMessage($"El jugador {player.Name} ya está encarcelado.");
                return;
            }

            Vector3 originalPosition = player.Position;

            AdminJailPlayerData playerData = new AdminJailPlayerData()
            {
                OriginalPosition = originalPosition,
                JailReleaseTime = jailTime,
                JailReason = reason
            };

            jailedPlayers.Add(playerID, playerData);

            player.Position = jailCellPosition;
        }

    }
}
