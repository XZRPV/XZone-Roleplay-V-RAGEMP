using GTANetworkAPI;
using XZRPV.Models;

namespace XZRPV.Library.Extensions
{
    public class ScriptExtended : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            User.OnCharacterSpawned += OnCharacterSpawned;
        }

        public virtual void OnCharacterSpawned(User pUser, Player player) { }
    }
}
