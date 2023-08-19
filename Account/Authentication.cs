using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using XZRPV.Database;
using XZRPV.Models;

namespace XZRPV.Account
{
    public class Authentication : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            NAPI.Entity.SetEntityTransparency(player, 0);

            player.TriggerEvent("ShowLoginPage::Client");
        }

        [RemoteEvent("LoginInfoFromClient")]
        public void LoginInfoFromClient(Player player, string payload)
        {
            NAPI.Util.ConsoleOutput("log in");
            NAPI.Util.ConsoleOutput(payload);

            var loginInfo = JObject.Parse(payload);

            var username = (string)loginInfo["user"];
            var pswd = (string)loginInfo["pswd"];

            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(pswd))
            {
                player.TriggerEvent("RemoveLoading::Client");
                return;
            }

            User pUser = null;

            using (DbConn db = new DbConn())
            {
                pUser = db.Users
                        .Include(u => u.UserCharacter)
                        .Where(x => String.Equals(username, x.Username))
                        .FirstOrDefault();
            }

            if (pUser == null)
            {
                NAPI.Util.ConsoleOutput("Este usuario no existe!");
                player.TriggerEvent("RemoveLoading::Client");

                return;
            }

            if (!pUser.VerifyPassword(player, (string)loginInfo["pswd"]))
            {
                // TODO: Limit the amount of attempts to 3 and then kick him
                NAPI.Util.ConsoleOutput("Contraseña invalida!");
                player.TriggerEvent("RemoveLoading::Client");
                return;
            }

            pUser.PlayerData = player;

            player.TriggerEvent("RemoveLoading::Client");
            player.TriggerEvent("DestroyLogin::Client");

            pUser.SpawnCharacter();
        }

        [RemoteEvent("SignupInfoFromClient")]
        public void SignupInfoFromClient(Player player, string payload)
        {
            NAPI.Util.ConsoleOutput("sign up");
            NAPI.Util.ConsoleOutput(payload);

            var signupInfo = JObject.Parse(payload);

            var username = (string)signupInfo["user"];
            var email = (string)signupInfo["email"];
            var pswd = (string)signupInfo["pswd"];
            var confirmPswd = (string)signupInfo["confirmPswd"];

            if (String.IsNullOrWhiteSpace(username) ||
                String.IsNullOrWhiteSpace(email) ||
                String.IsNullOrWhiteSpace(pswd) ||
                String.IsNullOrWhiteSpace(confirmPswd))
            {
                player.TriggerEvent("RemoveLoading::Client");
                return;
            }

            User pUser = null;

            using (DbConn db = new DbConn())
            {
                pUser = db.Users.Where(x => String.Equals(username, x.Username)
                                        || String.Equals(email, x.Email))
                                        .FirstOrDefault();
            }

            if (pUser != null)
            {
                NAPI.Util.ConsoleOutput("Esta usuario o correo ya se encuentra registrado!");
                player.TriggerEvent("RemoveLoading::Client");
                return;
            }

            if (!String.Equals(pswd, confirmPswd))
            {
                NAPI.Util.ConsoleOutput("Las contraseña no coinciden");
                player.TriggerEvent("RemoveLoading::Client");
                return;
            }

            using (DbConn db = new DbConn())
            {
                var userAccount = new User
                {
                    Username = username,
                    Email = email
                };
                userAccount.Password = userAccount.HashPassword(player, pswd);

                var users = db.Set<User>();
                users.Add(userAccount);

                db.SaveChanges();

                pUser = userAccount;
            }

            pUser.PlayerData = player;

            player.TriggerEvent("RemoveLoading::Client");
            player.TriggerEvent("DestroyLogin::Client");

            pUser.SpawnCharacter();
        }
    }
}
