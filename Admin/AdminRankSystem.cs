using GTANetworkAPI;
using System.Collections.Generic;

namespace XZRPV.Admin
{
    public class AdminRankSystem : Script
    {
        public const int USER = 0;
        public const int MODERATOR = 1;
        public const int MODERATOR_LEADER = 2;
        public const int ADMINISTRATOR = 3;
        public const int ADMINISTRATOR_LEADER = 4;
        public const int OWNER = 5;
        public Dictionary<int, string> AdminRanks { get; set; }

        public AdminRankSystem()
        {
            AdminRanks = new Dictionary<int, string>()
            {
                { USER, "Usuario" },
                { MODERATOR, "Moderador" },
                { MODERATOR_LEADER, "Lider de Moderadores" },
                { ADMINISTRATOR, "Administrador" },
                { ADMINISTRATOR_LEADER, "Lider de Administradores" },
                { OWNER, "Dueño" }
            };
        }
        
        public string GetRankName(int rankId)
        {
            if (AdminRanks[rankId] == null)
            {
                return "N/A";
            }

            return AdminRanks[rankId];
        }
    }
}
