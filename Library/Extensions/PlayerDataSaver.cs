using GTANetworkAPI;
using System.Timers;
using XZRPV.Models;

namespace XZRPV.Library.Extensions
{
    public class PlayerDataSaver
    {
        public readonly Timer saveTimer;
        private readonly Player localPlayer;

        public PlayerDataSaver(Player player)
        {
            localPlayer = player;
            saveTimer = new Timer
            {
                Interval = 60_000 // 1 minute in milliseconds
            };
            saveTimer.Elapsed += OnSaveTimerElapsed;
            saveTimer.Start();
        }

        private void OnSaveTimerElapsed(object sender, ElapsedEventArgs e)
        {
            NAPI.Task.Run(() =>
            {
                User pUser = localPlayer.GetUserData();

                if (localPlayer != null && localPlayer.Position != null)
                {
                    pUser.PosX = localPlayer.Position.X;
                    pUser.PosY = localPlayer.Position.Y;
                    pUser.PosZ = localPlayer.Position.Z;
                }

                pUser.Save();
            });
        }
    }
}
