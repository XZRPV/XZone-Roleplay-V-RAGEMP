using GTANetworkAPI;
using XZRPV.Library;
using XZRPV.Library.Extensions;

namespace XZRPV.Admin
{
    public class AdminSystem : Script
    {
        public static void NotifyAdmins(string message)
        {
            string formattedMessage = $"!{{#00FFFF}}{message}";

            foreach (Player playerOnline in PlayerHandler.GetPlayerList())
            {
                if (playerOnline.GetUserData().AdminRankId > AdminRankSystem.USER)
                {
                    playerOnline.SendChatMessage(formattedMessage);
                }
            }
        }

        public static void NotifyUsers(string message)
        {
            string formattedMessage = $"!{{#00FFFF}}{message}";

            foreach (Player player in PlayerHandler.GetPlayerList())
            {
                player.SendChatMessage(formattedMessage);
            }
        }
    }
}
