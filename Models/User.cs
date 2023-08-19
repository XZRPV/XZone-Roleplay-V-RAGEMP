

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Timers;
using GTANetworkAPI;
using XZRPV.Account;
using XZRPV.Admin;
using XZRPV.Database;
using XZRPV.Factions;
using XZRPV.Library;

namespace XZRPV.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public decimal Money { get; set; }
        public decimal BankBalance { get; set; }
        public int AdminRankId { get; set; }
        public int FactionId { get; set; }
        public int FactionRankId { get; set; }
        public int JobId { get; set; }
        public bool Gender { get; set; }
        public bool IsDead { get; set; }
        public ICollection<House> Houses { get; set; }
        public UserCharacter UserCharacter { get; set; } = new UserCharacter();

        [NotMapped]
        public string Fullname => Firstname + "_" + Lastname;

        [NotMapped]
        public Faction Faction => (Faction)FactionManager.GetFactionByID(FactionId);

        [NotMapped]
        public string FactionRankName => Faction.GetRankName(FactionRankId);

        [NotMapped]
        public Vector3 LastKnownPos => new Vector3(PosX, PosY, PosZ);

        [NotMapped]
        public string AdminRankName => new AdminRankSystem().GetRankName(AdminRankId);

        [NotMapped]
        public string GenderName => Gender ? "Hombre" : "Mujer";

        [NotMapped]
        public Timer PlayerDataSaveTimer { get; set; }

        [NotMapped]
        public Player PlayerData
        {
            get
            {
                return playerData;
            }
            set
            {
                value.SetData(AccountHandler.USER_DATA, this);
                playerData = value;
            }
        }
        private Player playerData;

        public bool VerifyPassword(Player player, string password)
        {
            bool isPassValid = BCrypt.Net.BCrypt.Verify(password, Password);
            return isPassValid;
        }

        public string HashPassword(Player player, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static event Action<User, Player> OnCharacterSpawned;

        public void SpawnCharacter()
        {
            if (IsDead)
            {
                Vector3 position = new Vector3(298.381, -584.152, 43.17);
                NAPI.Entity.SetEntityPosition(playerData, position);

                IsDead = false;
            }
            else
            {
                PlayerData.Position = LastKnownPos;
            }

            PlayerData.Name = Fullname;
            PlayerData.Transparency = 255;
            PlayerData.Dimension = 0;

            AssignPlayerGender(PlayerData);
            UserCharacter?.ApplyPlayerOutfit(PlayerData);

            PlayerHandler.AddPlayerToList(PlayerData);

            OnCharacterSpawned?.Invoke(this, PlayerData);
        }

        private void AssignPlayerGender(Player PlayerData)
        {
            HeadBlend headBlend = new HeadBlend();
            Dictionary<int, HeadOverlay> headOverlays = new Dictionary<int, HeadOverlay>() { };
            Decoration[] decorations = new Decoration[10];

            PlayerData.SetCustomization(this.Gender, headBlend, 0, 0, 0, new float[20], headOverlays, decorations);
        }

        public void Save()
        {
            UserCharacter.SavePlayerClothes(PlayerData);

            using (DbConn db = new DbConn())
            {
                db.Users.Update(this);
                db.SaveChanges();
            }
        }
    }
}
