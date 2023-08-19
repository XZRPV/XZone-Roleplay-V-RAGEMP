
using GTANetworkAPI;
using XZRPV.Account;
using XZRPV.Models;

namespace XZRPV.Library.Extensions
{
    public static class PlayerExtensions
    {
        public static User GetUserData(this Player player)
        {
            if (player == null || !player.HasData(AccountHandler.USER_DATA))
                return null;

            return player.GetData<User>(AccountHandler.USER_DATA);
        }
    }
}
