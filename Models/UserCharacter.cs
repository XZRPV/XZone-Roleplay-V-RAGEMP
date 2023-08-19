
using GTANetworkAPI;

namespace XZRPV.Models
{
    public class UserCharacter
    {
        public int UserCharacterId { get; set; }
        public int Torso { get; set; }
        public int Undershirt { get; set; }
        public int Top { get; set; }
        public int Legs { get; set; }
        public int Shoes { get; set; }
        public int Hair { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public void ApplyPlayerOutfit(Player player)
        {
            player.SetClothes(Clothing.Clothing.COMPONENT_ID_TORSO, Torso, 0);
            player.SetClothes(Clothing.Clothing.COMPONENT_ID_UNDERSHIRT, Undershirt, 0);
            player.SetClothes(Clothing.Clothing.COMPONENT_ID_TOP, Top, 0);
            player.SetClothes(Clothing.Clothing.COMPONENT_ID_LEGS, Legs, 0);
            player.SetClothes(Clothing.Clothing.COMPONENT_ID_SHOES, Shoes, 0);
            player.SetClothes(Clothing.Clothing.COMPONENT_ID_HAIR, Hair, 0);
        }

        public void SavePlayerClothes(Player player)
        {
            Torso = player.GetClothesDrawable(Clothing.Clothing.COMPONENT_ID_TORSO);
            Undershirt = player.GetClothesDrawable(Clothing.Clothing.COMPONENT_ID_UNDERSHIRT);
            Top = player.GetClothesDrawable(Clothing.Clothing.COMPONENT_ID_TOP);
            Legs = player.GetClothesDrawable(Clothing.Clothing.COMPONENT_ID_LEGS);
            Shoes = player.GetClothesDrawable(Clothing.Clothing.COMPONENT_ID_SHOES);
            Hair = player.GetClothesDrawable(Clothing.Clothing.COMPONENT_ID_HAIR);
        }
    }
}
