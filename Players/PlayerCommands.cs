using GTANetworkAPI;
using System.Collections.Generic;
using XZRPV.Clothing;
using XZRPV.Database;
using XZRPV.Houses;
using XZRPV.Library;
using XZRPV.Library.Chat;
using XZRPV.Library.Extensions;
using XZRPV.Models;
using static XZRPV.Clothing.Clothing;

namespace XZRPV.Players
{
    public class PlayerCommands : Script
    {
        [Command("me", GreedyArg = true)]
        public void PrintMeAction(Player player, string text)
        {
            string message = $"* {player.Name} {text}";
            MessageFunctions.SendMessageToPlayersInRadiusColored(player, ChatDistances.ME_DST, message, ChatColors.ME_COLOR, excludingSelf: false);
        }

        [Command("do", GreedyArg = true)]
        public void PrintDoAction(Player player, string text)
        {
            string message = $"* {text} (( {player.Name} ))";
            MessageFunctions.SendMessageToPlayersInRadiusColored(player, 30, message, ChatColors.DO_COLOR, excludingSelf: false);
        }

        [Command("pagar")]
        public void PayCommand(Player player, string target, int amount)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);

            User sender = player.GetUserData();
            User receiver = targetPlayer.GetUserData();

            if (receiver == null)
            {
                player.SendChatMessage($"El jugador {targetPlayer.Name} no existe.");
                return;
            }

            if (receiver == sender)
            {
                player.SendChatMessage("No puedes pagarte a ti mismo.");
                return;
            }

            if (sender.Money < amount)
            {
                player.SendChatMessage("No tienes suficiente dinero para pagar.");
                return;
            }

            MoneySystem.RemovePlayerMoney(player, amount);
            MoneySystem.AddPlayerMoney(targetPlayer, amount);

            player.SendChatMessage($"Has pagado {amount} al jugador {targetPlayer.Name}.");
            targetPlayer.SendChatMessage($"{player.Name} te ha pagado {amount}.");
        }

        [Command("depositardinero")]
        public void DepositInBank(Player player, int amount)
        {
            User pUser = player.GetUserData();

            if (pUser.Money < amount)
            {
                player.SendChatMessage("No tienes suficiente dinero para depositar.");
                return;
            }

            BankSystem.AddMoneyToBank(pUser, amount);
            MoneySystem.RemovePlayerMoney(player, amount);
        }

        [Command("retirardinero")]
        public void WithdrawFromBank(Player player, int amount)
        {
            User pUser = player.GetUserData();

            if (pUser.BankBalance < amount)
            {
                player.SendChatMessage("No tienes suficiente dinero en el banco para retirar.");
                return;
            }

            BankSystem.RemoveMoneyFromBank(pUser, amount);
            MoneySystem.AddPlayerMoney(player, amount);
        }

        [Command("consultarsaldo")]
        public void CheckBalance(Player player)
        {
            User pUser = player.GetUserData();
            player.SendChatMessage($"Tu saldo en el banco es de {pUser.BankBalance}.");
        }

        [Command("transferirdinero")]
        public void TransferMoney(Player player, string target, int amount)
        {
            Player targetPlayer = PlayerHandler.GetPlayer(target);

            User sender = player.GetUserData();
            User receiver = targetPlayer.GetUserData();

            if (targetPlayer == null)
            {
                player.SendChatMessage($"No se ha encontrado un jugador con nombre o id {target}");
                return;
            }

            if (targetPlayer == player)
            {
                player.SendChatMessage("No puedes transferirte dinero a ti mismo.");
                return;
            }

            if (amount <= 0)
            {
                player.SendChatMessage("No puedes transferir cantidades negativas o 0.");
                return;
            }

            if (sender.BankBalance < amount)
            {
                player.SendChatMessage("No tienes suficiente dinero en el banco para transferir.");
                return;
            }

            BankSystem.RemoveMoneyFromBank(sender, amount);
            BankSystem.AddMoneyToBank(receiver, amount);

            player.SendChatMessage($"Has transferido {amount} al jugador {targetPlayer.Name}.");
            targetPlayer.SendChatMessage($"Has recibido {amount} del jugador {player.Name}.");
        }

        [Command("online")]
        public void PrintPlayersOnline(Player player)
        {
            var playerLst = PlayerHandler.PlayerList;
            player.SendChatMessage($"Hay {playerLst.Count} jugador(es) conectados");

            foreach (var kp in playerLst)
                player.SendChatMessage($"Jugador: {kp.Value.Name}, ID: {kp.Key}");
        }

        [Command("cambiarsexo")]
        public void CambiarSexo(Player player, int val)
        {
            HeadBlend headBlend = new HeadBlend();
            Dictionary<int, HeadOverlay> headOverlays = new Dictionary<int, HeadOverlay>() { };
            Decoration[] decorations = new Decoration[10];

            bool gender = val != 0;

            player.SetCustomization(gender, headBlend, 0, 0, 0, new float[20], headOverlays, decorations);
            player.GetUserData().Gender = gender;

            player.SendChatMessage($"Tu género ha sido cambiado a {player.GetUserData().GenderName}");
        }

        [Command("ropatorso")]
        public void ChangeClothesTop(Player player, int slot)
        {
            AssignPlayerClothesTop(player, slot);
        }

        [Command("ropapiernas")]
        public void ChangeClothesBottom(Player player, int slot)
        {
            AssignPlayerClothesBottom(player, slot);
        }

        [Command("ropacabello")]
        public void ChangeClothesHair(Player player, int slot)
        {
            AssignPlayerClothesHair(player, slot);
        }

        [Command("entrarcasa")]
        public void EnterHouseCommand(Player player, int houseId)
        {
            House house = HouseManager.GetHouseById(houseId);

            if (house == null)
            {
                player.SendChatMessage($"No se ha encontrado una casa con ID: {houseId}.");
                return;
            }

            if (house.IsLocked)
            {
                player.SendChatMessage($"La casa con ID: {houseId} está cerrada.");
                return;
            }

            player.Position = new Vector3(house.ExitX, house.ExitY, house.ExitZ);
            player.Dimension = house.VirtualWorldId;

            player.SendChatMessage($"Has entrado a la casa con ID: {houseId}.");
        }

        [Command("salircasa")]
        public void ExitHouseCommand(Player player, int houseId)
        {
            House house = HouseManager.GetHouseById(houseId);

            if (house == null)
            {
                player.SendChatMessage($"No se ha encontrado una casa con ID: {houseId}.");
                return;
            }

            player.Position = new Vector3(house.EntranceX, house.EntranceY, house.EntranceZ);
            player.Dimension = 0;

            player.SendChatMessage($"Has salido de la casa con ID: {houseId}.");
        }

        [Command("segurocasa")]
        public void LockHouseCommand(Player player, int houseId)
        {
            House house = HouseManager.GetHouseById(houseId);

            if (house == null)
            {
                player.SendChatMessage($"No se ha encontrado una casa con ID: {houseId}.");
                return;
            }

            if (house.UserId != player.GetUserData().UserId)
            {
                player.SendChatMessage($"No eres el dueño de la casa con ID: {houseId}.");
                return;
            }

            house.IsLocked = !house.IsLocked;

            using (DbConn db = new DbConn())
            {
                var houses = db.Set<House>();
                houses.Attach(house);
                houses.Update(house);

                db.SaveChanges();
            }

            player.SendChatMessage($"Has {(house.IsLocked ? "cerrado" : "abierto")} la casa con ID: {houseId}.");
        }

        [Command("comprarcasa")]
        public void BuyHouseCommand(Player player, int houseId)
        {
            House house = HouseManager.GetHouseById(houseId);

            if (house == null)
            {
                player.SendChatMessage($"No se ha encontrado una casa con ID: {houseId}.");
                return;
            }

            if (house.UserId != null)
            {
                player.SendChatMessage($"La casa con ID: {houseId} ya está comprada.");
                return;
            }

            if (player.GetUserData().Money < house.Price)
            {
                player.SendChatMessage($"No tienes suficiente dinero para comprar la casa con ID: {houseId}.");
                return;
            }

            MoneySystem.RemovePlayerMoney(player, (int)house.Price);

            house.UserId = player.GetUserData().UserId;

            using (DbConn db = new DbConn())
            {
                var houses = db.Set<House>();
                houses.Attach(house);
                houses.Update(house);

                db.SaveChanges();
            }

            player.SendChatMessage($"Has comprado la casa con ID: {houseId}.");
        }

        [Command("vendercasa")]
        public void SellHouseCommand(Player player, int houseId)
        {
            House house = HouseManager.GetHouseById(houseId);

            if (house == null)
            {
                player.SendChatMessage($"No se ha encontrado una casa con ID: {houseId}.");
                return;
            }

            if (house.UserId != player.GetUserData().UserId)
            {
                player.SendChatMessage($"No eres el dueño de la casa con ID: {houseId}.");
                return;
            }

            MoneySystem.AddPlayerMoney(player, (int)house.Price);

            house.UserId = null;
            house.IsLocked = true;

            using (DbConn db = new DbConn())
            {
                var houses = db.Set<House>();
                houses.Attach(house);
                houses.Update(house);

                db.SaveChanges();
            }

            player.SendChatMessage($"Has vendido la casa con ID: {houseId}.");
        }

        [Command("c")]
        public void CutsceneCommand(Player player, string cutsceneName)
        {
            player.TriggerEvent("Cutscene", cutsceneName);
        }
    }
}
