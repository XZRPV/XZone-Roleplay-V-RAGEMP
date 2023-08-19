using GTANetworkAPI;
using XZRPV.Library;
using XZRPV.Library.Extensions;
using XZRPV.Models;
using XZRPV.Players;

namespace XZRPV.Account
{
    public class AccountHandler : ScriptExtended
    {
        public static readonly string USER_DATA = "UserData";

        public override void OnCharacterSpawned(User pUser, Player player)
        {
            pUser.PlayerDataSaveTimer?.Dispose();
            pUser.PlayerDataSaveTimer = new PlayerDataSaver(player).saveTimer;

            player.TriggerEvent(MoneySystem.MoneyHUDSetEvent, player.GetUserData().Money);
        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            player.TriggerEvent("ShowLoginPage::Client");
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Player player, DisconnectionType type, string reason)
        {
            User pUser = player.GetUserData();

            if (pUser == null || player == null) return;

            pUser.PlayerDataSaveTimer?.Dispose();

            PlayerHandler.RemovePlayerFromPlayerList(player);

            pUser.PosX = player.Position.X;
            pUser.PosY = player.Position.Y;
            pUser.PosZ = player.Position.Z;

            pUser.Save();
        }

        [ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Player player, Player killer, uint reason)
        {
            User pUser = player.GetUserData();
            pUser.IsDead = true;
        }

        [ServerEvent(Event.PlayerSpawn)]
        public void OnPlayerSpawn(Player player)
        {
            User pUser = player.GetUserData();

            if (pUser == null) return;

            Vector3 position = new Vector3(298.381, -584.152, 43.17);
            NAPI.Entity.SetEntityPosition(player, position);
            pUser.IsDead = false;
        }
    }
}
