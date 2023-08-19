using GTANetworkAPI;
using XZRPV.Factions;
using XZRPV.Library.Extensions;
using XZRPV.Models;

namespace XZRPV.Jobs
{
    public class JobCommands : Script
    {
        [Command("unirse")]
        public void JoinJobCommand(Player player, int jobId)
        {
            IJob job = JobManager.GetJobByID(jobId);

            if (job == null)
            {
                player.SendChatMessage("El trabajo no existe.");
                return;
            }

            User pUser = player.GetUserData();

            if (pUser.JobId != 0)
            {
                player.SendChatMessage("Ya tienes un trabajo.");
                return;
            }

            pUser.JobId = jobId;
            player.SendChatMessage($"Te has unido al trabajo de {job.Name}.");
        }

        [Command("salirse")]
        public void LeaveJobCommand(Player player)
        {
            User pUser = player.GetUserData();

            if (pUser.JobId == 0)
            {
                player.SendChatMessage("No tienes un trabajo.");
                return;
            }
            
            pUser.JobId = 0;
            player.SendChatMessage($"Has salido del trabajo");
        }

        [Command("trabajo")]
        public void JobCommand(Player player)
        {
            User pUser = player.GetUserData();

            if (pUser.JobId == 0)
            {
                player.SendChatMessage("No tienes un trabajo.");
                return;
            }

            IJob job = JobManager.GetJobByID(pUser.JobId);
            player.SendChatMessage($"Estas trabajando en {job.Name}.");
        }
    }
}
