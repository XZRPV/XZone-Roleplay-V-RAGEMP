﻿using GTANetworkAPI;
using System.Collections.Generic;
using System.Linq;

namespace XZRPV.Library
{
    public class PlayerHandler
    {
        public static readonly Dictionary<int, Player> PlayerList = new Dictionary<int, Player>();

        public static void AddPlayerToList(Player player)
        {
            // Lock the playerlist while a free id is being found
            lock (PlayerList)
            {
                int freeID = GetFreeID();
                PlayerList.Add(freeID, player);
            }
        }

        public static List<Player> GetPlayerList()
        {
            return PlayerList.Values.ToList();
        }

        public static Player GetPlayer(int id)
        {
            return PlayerList.ContainsKey(id) ? PlayerList[id] : null;
        }

        public static Player GetPlayer(string name)
        {
            if (int.TryParse(name, out int id))
                return GetPlayer(id);

            return PlayerList.Values.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public static int GetIDFromPlayer(Player player)
        {
            var entry = PlayerList.Where(e => e.Value == player)
                        .Select(e => (KeyValuePair<int, Player>?)e)
                        .FirstOrDefault();
            return entry == null ? -1 : (int)entry?.Key;
        }

        public static void RemovePlayerFromPlayerList(Player player)
        {
            // Lock the playerlist while the player is removed
            lock (PlayerList)
            {
                int playerID = GetIDFromPlayer(player);
                if (playerID != -1)
                {
                    PlayerList.Remove(playerID);
                }
            }
        }
        private static int GetFreeID()
        {
            List<int> currentIds = PlayerList.Keys.ToList();
            int freeID = 1;
            for (int i = 0; i < currentIds.Count; i++)
            {
                if (freeID != currentIds[i])
                    break;
                else freeID++;
            }

            return freeID;
        }
    }
}
