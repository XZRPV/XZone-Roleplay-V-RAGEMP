
namespace XZRPV.Players
{
    using GTANetworkAPI;
    using XZRPV.Library.Extensions;
    using XZRPV.Models;

    public class MoneySystem : Script
    {
        public static string MoneyHUDAddEvent = "moneyhud:add";
        public static string MoneyHUDRemoveEvent = "moneyhud:remove";
        public static string MoneyHUDSetEvent = "moneyhud:set";

        public static void AddPlayerMoney(Player player, int amount)
        {
            User pUser = player.GetUserData();
            pUser.Money += amount;

            player.TriggerEvent(MoneyHUDAddEvent, amount);
        }

        public static void RemovePlayerMoney(Player player, int amount)
        {
            User pUser = player.GetUserData();
            pUser.Money -= amount;

            player.TriggerEvent(MoneyHUDRemoveEvent, amount);
        }

        public static void SetPlayerMoney(Player player, int amount)
        {
            User pUser = player.GetUserData();
            pUser.Money = amount;

            player.TriggerEvent(MoneyHUDSetEvent, amount);
        }
    }

}
