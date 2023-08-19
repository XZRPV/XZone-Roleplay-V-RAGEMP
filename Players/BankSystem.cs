using GTANetworkAPI;
using XZRPV.Models;

namespace XZRPV.Players
{
    public class BankSystem : Script
    {
        public static void AddMoneyToBank(User pUser, int amount)
        {
            pUser.BankBalance += amount;
        }

        public static void RemoveMoneyFromBank(User pUser, int amount)
        {
            pUser.BankBalance -= amount;
        }
    }
}

