using RAGE;

namespace XZRPV.Client.Admin
{
    public class AdminSystem : Events.Script
    {
        public AdminSystem()
        {
            Events.Add("AdminSystem:FreezePlayer", FreezePlayer);
        }

        private void FreezePlayer(object[] args)
        {
            bool freeze = (bool)args[0];
            RAGE.Game.Entity.FreezeEntityPosition(RAGE.Elements.Player.LocalPlayer.Handle, freeze);
        }
    }
}
