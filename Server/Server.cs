using GTANetworkAPI;

namespace XZRPV.Server
{
    public class Server : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            //NAPI.Server.SetAutoRespawnAfterDeath(false);
            NAPI.Server.SetAutoSpawnOnConnect(false);
            NAPI.Server.SetGlobalServerChat(false);
            //NAPI.Server.SetCommandErrorMessage("");
        }
    }
}
