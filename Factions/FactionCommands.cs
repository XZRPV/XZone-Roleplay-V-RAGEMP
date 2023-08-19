using GTANetworkAPI;
using System;
using XZRPV.Library;
using XZRPV.Library.Extensions;
using XZRPV.Models;

namespace XZRPV.Factions
{
    public class FactionCommands : Script
    {
        [Command("f", GreedyArg = true)]
        public void FactionChatCommand(Player player, string message)
        {
            User pUser = player.GetUserData();
            
            if (pUser.FactionId == 0)
            {
                player.SendChatMessage("No perteneces a ninguna facción.");
                return;
            }

            pUser.Faction.SendFactionMessage(player, message);
        }


        [Command("invitarf")]
        public void InviteCommand(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);

            User pUser = player.GetUserData();

            if (pUser.Faction.IsPlayerLeader(pUser) == false)
            {
                player.SendChatMessage("No tienes permisos para usar este comando.");
                return;
            }
 
            if (targetPlayer == null)
            {
                player.SendChatMessage("No se ha encontrado al jugador.");
                return;
            }

            if (player == targetPlayer)
            {
                player.SendChatMessage("No puedes invitarte a ti mismo.");
                return;
            }

            User receiver = targetPlayer.GetUserData();


            if (receiver.FactionId != 0)
            {
                player.SendChatMessage("El jugador ya pertenece a una facción.");
                return;
            }

            receiver.FactionId = pUser.FactionId;
            receiver.FactionRankId = 1;

            pUser.Faction.NotifyFactionMembers($"{player.Name} ha invitado a {receiver.Fullname} a {pUser.Faction.Name}.");
        }

        [Command("expulsarf")]
        public void KickPlayerCommand(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);

            User pUser = player.GetUserData();

            if (pUser.Faction.IsPlayerLeader(pUser) == false)
            {
                player.SendChatMessage("No tienes permisos para usar este comando.");
                return;
            }

            if (targetPlayer == null)
            {
                player.SendChatMessage("No se ha encontrado al jugador.");
                return;
            }

            if (player == targetPlayer)
            {
                player.SendChatMessage("No puedes expulsarte a ti mismo.");
                return;
            }

            User receiver = targetPlayer.GetUserData();

            if (receiver.FactionId != pUser.FactionId)
            {
                player.SendChatMessage("El jugador no pertenece a tu facción.");
                return;
            }
            receiver.FactionId = 0;
            receiver.FactionRankId = 0;

            pUser.Faction.NotifyFactionMembers($"{receiver.Fullname} ha sido expulsado de {pUser.Faction.Name}.");
        }

        [Command("promoverf")]
        public void PromotePlayerCommand(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);

            User pUser = player.GetUserData();

            if (pUser.Faction.IsPlayerLeader(pUser) == false)
            {
                player.SendChatMessage("No tienes permisos para usar este comando.");
                return;
            }

            if (targetPlayer == null)
            {
                player.SendChatMessage("No se ha encontrado al jugador.");
                return;
            }

            if (player == targetPlayer)
            {
                player.SendChatMessage("No puedes promocionarte a ti mismo.");
                return;
            }

            User receiver = targetPlayer.GetUserData();

            if (receiver.FactionId != pUser.FactionId)
            {
                player.SendChatMessage("El jugador no pertenece a tu facción.");
                return;
            }
            if (receiver.FactionRankId == pUser.Faction.Ranks.Count)
            {
                player.SendChatMessage($"No puedes promocionar más a {receiver.Firstname} {receiver.Lastname}");
                return;
            }

            receiver.FactionRankId++;
            pUser.Faction.NotifyFactionMembers($"{receiver.Fullname} ha sido ascendido a {receiver.FactionRankName}.");
        }

        [Command("degradarf")]
        public void DemotePlayerCommand(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);

            User pUser = player.GetUserData();

            if (pUser.Faction.IsPlayerLeader(pUser) == false)
            {
                player.SendChatMessage("No tienes permisos para usar este comando.");
                return;
            }

            if (targetPlayer == null)
            {
                player.SendChatMessage("No se ha encontrado al jugador.");
                return;
            }

            if (player == targetPlayer)
            {
                player.SendChatMessage("No puedes degradarte a ti mismo.");
                return;
            }

            User receiver = targetPlayer.GetUserData();

            if (receiver.FactionId != pUser.FactionId)
            {
                player.SendChatMessage("El jugador no pertenece a tu facción.");
                return;
            }

            if (receiver.FactionRankId == 1)
            {
                player.SendChatMessage($"No puedes degradar más a {receiver.Fullname}");
                return;
            }

            receiver.FactionRankId--;
            pUser.Faction.NotifyFactionMembers($"{receiver.Fullname} ha sido degradado a {receiver.FactionRankName}.");
        }

        [Command("miembrosf")]
        public void FactionMembersCommand(Player player)
        {

            User sender = player.GetUserData();

            int playerFactionId = sender.FactionId;

            if (playerFactionId == 0)
            {
                player.SendChatMessage("No perteneces a ninguna facción.");
                return;
            }

            player.SendChatMessage("Miembros de la facción:");

            foreach (Player p in PlayerHandler.GetPlayerList())
            {
                User user = p.GetUserData();

                if (user.FactionId == playerFactionId)
                {
                    player.SendChatMessage($"- {user.FactionRankName} {p.Name}");
                }
            }
        }
    }
}
