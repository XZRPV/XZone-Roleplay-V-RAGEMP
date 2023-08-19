using GTANetworkAPI;
using XZRPV.Library.Chat;
using XZRPV.Library.Extensions;
using XZRPV.Models;

namespace XZRPV.Factions.SAPD
{
    public class SAPDCommands : Script
    {
        [Command("megafono")]
        public void MegafonoCommand(Player player, string message)
        {
            User pUser = player.GetUserData();
            
            if (pUser.FactionRankId < SAPD.OFFICER)
            {
                player.SendChatMessage("No tienes permisos para usar este comando.");
                return;
            }

            MessageFunctions.SendMessageToPlayersInRadiusColored(player, 30, message, ChatColors.MEGAPHONE_COLOR, excludingSelf: false);
        }
    }
}
