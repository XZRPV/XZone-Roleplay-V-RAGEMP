using GTANetworkAPI;
using System;
using XZRPV.Database;
using XZRPV.Factions;
using XZRPV.Houses;
using XZRPV.Library;
using XZRPV.Library.Extensions;
using XZRPV.Models;
using XZRPV.Players;
using static XZRPV.Admin.AdminRankSystem;

namespace XZRPV.Admin
{
    public class AdminCommands : Script
    {
        private AdminJailSystem adminJail;

        public AdminCommands()
        {
            adminJail = new AdminJailSystem();
        }

        [Command("haceradmin")]
        public void MakeAdminCommand(Player player, string target, int adminRankId)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            User receiver = targetPlayer.GetUserData();

            if (receiver.AdminRankId == OWNER)
            {
                player.SendChatMessage("No puedes promover a este jugador.");
                return;
            }

            receiver.AdminRankId = adminRankId;
            AdminSystem.NotifyAdmins($"{player.Name} ha promovido a {targetPlayer.Name} a {receiver.AdminRankName}.");
        }

        [Command("hacerlider")]
        public void MakeLeaderCommand(Player player, string target, int factionID)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            User targetPlayerData = targetPlayer.GetUserData();

            if (factionID == 0)
            {
                targetPlayerData.FactionId = 0;
                targetPlayerData.FactionRankId = 0;
                AdminSystem.NotifyAdmins($"{player.Name} ha quitado a {targetPlayer.Name} de su facción.");
                return;
            }

            IFaction faction = FactionManager.GetFactionByID(factionID);

            targetPlayerData.FactionId = factionID;
            targetPlayerData.FactionRankId = faction.Ranks.Count;

            AdminSystem.NotifyAdmins($"{player.Name} ha promovido a {targetPlayer.Name} a lider de {faction.Name}.");
        }

        [Command("dardinero")]
        public void AddMoneyCommand(Player player, int amount)
        {
            MoneySystem.AddPlayerMoney(player, amount);
        }

        [Command("quitardinero")]
        public void RemoveMoneyCommand(Player player, int amount)
        {
            MoneySystem.RemovePlayerMoney(player, amount);
        }

        [Command("setdinero")]
        public void SetMoneyCommand(Player player, int amount)
        {
            MoneySystem.SetPlayerMoney(player, amount);
        }

        [Command("kick")]
        public void KickCommand(Player player, string target, string reason)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            NAPI.Player.KickPlayer(targetPlayer, reason);
            AdminSystem.NotifyAdmins($"{player.Name} ha kickeado a {targetPlayer.Name}. Razón: {reason}");
        }

        [Command("ban")]
        public void BanCommand(Player player, string target, string reason)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            NAPI.Player.BanPlayer(targetPlayer, reason);
            AdminSystem.NotifyAdmins($"{player.Name} ha baneado a {targetPlayer.Name}. Razón: {reason}");
        }

        [Command("tp")]
        public void TeleportCommand(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            NAPI.Entity.SetEntityPosition(player, NAPI.Entity.GetEntityPosition(targetPlayer));
        }

        [Command("traer")]
        public void BringCommand(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            Vector3 adminPosition = player.Position;
            float adminRotation = player.Rotation.Z;

            float spawnDistance = 5.0f;

            float angle = (float)(adminRotation * Math.PI / 180.0);
            float x = (float)(Math.Cos(angle) * spawnDistance);
            float y = (float)(Math.Sin(angle) * spawnDistance);

            Vector3 spawnPosition = new Vector3(adminPosition.X + x, adminPosition.Y + y, adminPosition.Z);

            targetPlayer.Position = spawnPosition;
            player.SendChatMessage($"Has teletransportado a {targetPlayer.Name} hacia ti.");
        }

        [Command("espectar")]
        public void SpectateCommand(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);

            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            player.TriggerEvent("StartSpectatingTarget::Client", targetPlayer);
            NAPI.Entity.SetEntityTransparency(player, 0);
            player.SetData("OldSpectatePosition", player.Position);

            player.SendChatMessage($"You're now spectating {targetPlayer.Name}!");
            player.SendChatMessage("Use /unspectate to stop spectating this player.");
        }

        [Command("dejarespectar")]
        public void StopSpectatePlayer(Player player)
        {
            player.TriggerEvent("StopSpectatingTarget::Client");
            NAPI.Entity.SetEntityTransparency(player, 255);

            if (player.HasData("OldSpectatePosition"))
            {
                player.Position = player.GetData<Vector3>("OldSpectatePosition");
                player.ResetData("OldSpectatePosition");
            }

            player.SendChatMessage("You're no longer spectating anyone.");
        }

        [Command("kill")]
        public void KillCommand(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            NAPI.Player.SetPlayerHealth(targetPlayer, 0);
        }

        [Command("tpcoor")]
        public void TeleportToCoordinatesCommand(Player player, float x, float y, float z)
        {
            Vector3 position = new Vector3(x, y, z);
            NAPI.Entity.SetEntityPosition(player, position);
        }

        [Command("sethp")]
        public void SetHealthCommand(Player player, string target, int health)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            NAPI.Player.SetPlayerHealth(targetPlayer, health);
        }

        [Command("setarmor")]
        public void SetArmorCommand(Player player, string target, int armor)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            NAPI.Player.SetPlayerArmor(targetPlayer, armor);
        }

        [Command("a", GreedyArg = true)]
        public void AdminChatCommand(Player player, string message)
        {
            if (player.GetUserData().AdminRankId == USER)
            {
                player.SendChatMessage("No tienes permisos para usar este comando.");
                return;
            }

            AdminSystem.NotifyAdmins($"[AdminChat - {player.GetUserData().AdminRankName}] {player.Name}: {message}");
        }

        [Command("congelar")]
        public void FreezePlayer(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);

            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            if (player.GetUserData().AdminRankId != OWNER && targetPlayer.GetUserData().AdminRankId > USER)
            {
                player.SendChatMessage($"No puedes congelar a un administrador.");
                return;
            }

            targetPlayer.TriggerEvent("AdminSystem:FreezePlayer", true);
            player.SendChatMessage($"Has congelado al jugador {targetPlayer.Name}");
        }

        [Command("descongelar")]
        public void UnfreezePlayer(Player player, string target)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            if (player.GetUserData().AdminRankId != OWNER && targetPlayer.GetUserData().AdminRankId > USER)
            {
                player.SendChatMessage($"No puedes descongelar a un administrador.");
                return;
            }

            targetPlayer.TriggerEvent("AdminSystem:FreezePlayer", false);
            player.SendChatMessage($"Has descongelado al jugador {targetPlayer.Name}");
        }

        [Command("setarma")]
        public void GiveWeaponCommand(Player player, string target, string weaponName, int ammo = 100)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);

            if (player.GetUserData().AdminRankId == USER)
            {
                player.SendChatMessage("No tienes permiso para usar este comando.");
                return;
            }

            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id '{target}'");
                return;
            }

            WeaponHash weaponHash = NAPI.Util.WeaponNameToModel(weaponName);

            if (weaponHash == 0)
            {
                NAPI.Chat.SendChatMessageToPlayer(player, "Esa arma no existe!");
                return;
            }

            targetPlayer.GiveWeapon(weaponHash, ammo);

            player.SendChatMessage($"Has otorgado el arma '{weaponName}' al jugador {targetPlayer.Name} con {ammo} de munición.");
            targetPlayer.SendChatMessage($"Has recibido el arma '{weaponName}' con {ammo} de munición.");
        }

        [Command("quitararmas")]
        public void DisarmPlayerCommand(Player player, string target)
        {
            if (player.GetUserData().AdminRankId == USER)
            {
                player.SendChatMessage("No tienes permiso para usar este comando.");
                return;
            }

            Player targetPlayer = PlayerHandler.GetPlayer(target);
            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id '{target}'");
                return;
            }

            if (player.GetUserData().AdminRankId != OWNER && targetPlayer.GetUserData().AdminRankId > USER)
            {
                player.SendChatMessage($"No puedes desarmar a un administrador.");
                return;
            }

            targetPlayer.RemoveAllWeapons();

            player.SendChatMessage($"Has desarmado al jugador {targetPlayer.Name}.");
            targetPlayer.SendChatMessage($"Has sido desarmado por el staff {player.Name}");
        }


        [Command("jailear", GreedyArg = true)]
        public void JailPlayerCommand(Player player, string target, int minutes, string reason)
        {
            if (player.GetUserData().AdminRankId == USER)
            {
                player.SendChatMessage("No tienes permiso para usar este comando.");
                return;
            }

            Player targetPlayer = PlayerHandler.GetPlayer(target);

            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id '{target}'");
                return;
            }

            if (player.GetUserData().AdminRankId != OWNER && targetPlayer.GetUserData().AdminRankId > USER)
            {
                player.SendChatMessage($"No puedes encarcelar a un administrador.");
                return;
            }

            DateTime releaseTime = DateTime.UtcNow.AddMinutes(minutes);
            adminJail.JailPlayer(targetPlayer, reason, releaseTime);

            player.SendChatMessage($"Has sido encarcelado por {minutes} minutos. Razón: {reason}");

            string message = $"ha encarcelado al jugador {targetPlayer.Name} por {minutes} minutos. Razón: {reason}";
            AdminSystem.NotifyAdmins($"[AdminChat - {player.GetUserData().AdminRankName}] {player.Name}: {message}");
        }

        [Command("o", GreedyArg = true)]
        public void AdminChatGlobalCommand(Player player, string message)
        {
            if (player.GetUserData().AdminRankId < OWNER)
            {
                player.SendChatMessage("No tienes permisos para usar este comando.");
                return;
            }

            AdminSystem.NotifyUsers($"[Chat Global - {player.GetUserData().AdminRankName}] {player.Name}: {message}");
        }

        [Command("invisible")]
        public void SetTransparencyCommand(Player player)
        {
            if (player.GetUserData().AdminRankId == USER)
            {
                player.SendChatMessage("No tienes permiso para usar este comando.");
                return;
            }

            bool isPlayerVisible = (player.Transparency == 255);

            player.Transparency = isPlayerVisible ? 0 : 255;

            player.SendChatMessage($"Ahora eres {(isPlayerVisible ? "invisible" : "visible")}.");
        }

        [Command("crearveh")]
        public void CreateVehicleCommand(Player player, string vehicleName)
        {
            if (player.GetUserData().AdminRankId == USER)
            {
                player.SendChatMessage("No tienes permiso para usar este comando.");
                return;
            }

            VehicleHash vehicleHash = NAPI.Util.VehicleNameToModel(vehicleName);

            if (vehicleHash == 0)
            {
                NAPI.Chat.SendChatMessageToPlayer(player, "Ese vehículo no existe!");
                return;
            }

            Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehicleHash, player.Position.Around(2), player.Rotation.Z, 0, 0);
            vehicle.NumberPlate = "ADMIN";
            vehicle.EngineStatus = true;
            vehicle.Locked = false;

            player.SendChatMessage($"Has creado un vehículo de tipo '{vehicleName}'");
        }

        [Command("vehcoords")]
        public void GetVehicleCoordinatesCommand(Player player)
        {
            Vehicle vehicle = player.Vehicle;

            if (vehicle == null)
            {
                player.SendChatMessage("Debes estar en un vehículo para usar este comando.");
                return;
            }

            player.SendChatMessage($"XYZ: {vehicle.Position} | ROT: {vehicle.Rotation.Z}");
        }

        [Command("crearcasa")]
        public void CreateHouseCommand(Player player, int price)
        {
            if (player.GetUserData().AdminRankId != OWNER)
            {
                player.SendChatMessage("No tienes permiso para usar este comando.");
                return;
            }

            House house = new House()
            {
                EntranceX = player.Position.X,
                EntranceY = player.Position.Y,
                EntranceZ = player.Position.Z,
                ExitX = 0,
                ExitY = 0,
                ExitZ = 0,
                Price = price,
                InteriorId = 0,
                VirtualWorldId = 0,
                IsLocked = true,
                UserId = null
            };

            HouseManager.CreateHouse(house);

            player.SendChatMessage($"Has creado una casa con precio {price} e ID: {house.HouseId}.");
        }

        [Command("salidacasa")]
        public void SetHouseExitCommand(Player player, int houseId)
        {
            if (player.GetUserData().AdminRankId != OWNER)
            {
                player.SendChatMessage("No tienes permiso para usar este comando.");
                return;
            }

            House house = HouseManager.GetHouseById(houseId);

            if (house == null)
            {
                player.SendChatMessage($"No se ha encontrado una casa con ID: {houseId}.");
                return;
            }

            house.ExitX = player.Position.X;
            house.ExitY = player.Position.Y;
            house.ExitZ = player.Position.Z;
            HouseManager.CreateMarkerExit(house);

            HouseManager.UpdateHouse(house);

            player.SendChatMessage($"Has establecido la salida de la casa con ID: {houseId}.");
        }

        [Command("borrarcasa")]
        public void DeleteHouseCommand(Player player, int houseId)
        {
            if (player.GetUserData().AdminRankId != OWNER)
            {
                player.SendChatMessage("No tienes permiso para usar este comando.");
                return;
            }

            House house = HouseManager.GetHouseById(houseId);

            if (house == null)
            {
                player.SendChatMessage($"No se ha encontrado una casa con ID: {houseId}.");
                return;
            }

            HouseManager.DeleteHouse(house);

            player.SendChatMessage($"Has borrado la casa con ID: {houseId}.");
        }
    }
}
