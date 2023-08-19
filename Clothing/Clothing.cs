using GTANetworkAPI;
using XZRPV.Library.Extensions;
using XZRPV.Models;

namespace XZRPV.Clothing
{
    public class Clothing : Script
    {
        public const int COMPONENT_ID_UNDERSHIRT = 8;
        public const int COMPONENT_ID_TORSO = 3;
        public const int COMPONENT_ID_TOP = 11;
        public const int COMPONENT_ID_LEGS = 4;
        public const int COMPONENT_ID_SHOES = 6;
        public const int COMPONENT_ID_HAIR = 2;

        private static readonly ClothesTopData[] MALE_CLOTHESTOP = new ClothesTopData[]
        {
            new ClothesTopData { Undershirt = 15, Torso = 1, Top = 86 },
            new ClothesTopData { Undershirt = 44, Torso = 1, Top = 6 },
            new ClothesTopData { Undershirt = 15, Torso = 11, Top = 95 },
            new ClothesTopData { Undershirt = 115, Torso = 4, Top = 167 },
        };

        private static readonly ClothesTopData[] FEMALE_CLOTHESTOP = new ClothesTopData[]
        {
            new ClothesTopData { Undershirt = 2, Torso = 4, Top = 16 },
            new ClothesTopData { Undershirt = 2, Torso = 2, Top = 2 },
            new ClothesTopData { Undershirt = 1, Torso = 5, Top = 1 },
            new ClothesTopData { Undershirt = 2, Torso = 4, Top = 169 },
        };

        private static readonly ClothesBottomData[] MALE_CLOTHESBOTTOM = new ClothesBottomData[]
        {
            new ClothesBottomData { Legs = 1, Shoes = 80 },
            new ClothesBottomData { Legs = 22, Shoes = 55},
            new ClothesBottomData { Legs = 42, Shoes = 31 },
            new ClothesBottomData { Legs = 63, Shoes = 14 }
        };

        private static readonly ClothesBottomData[] FEMALE_CLOTHESBOTTOM = new ClothesBottomData[]
        {
            new ClothesBottomData { Legs = 4, Shoes = 6 },
            new ClothesBottomData { Legs = 2, Shoes = 3 },
            new ClothesBottomData { Legs = 78, Shoes = 5 },
            new ClothesBottomData { Legs = 8, Shoes = 15 }
        };

        private static readonly ClothesHairData[] MALE_CLOTHESHAIR = new ClothesHairData[]
        {
            new ClothesHairData { Hair = 14},
            new ClothesHairData { Hair = 13},
            new ClothesHairData { Hair = 49},
            new ClothesHairData { Hair = 11}
        };

        private static readonly ClothesHairData[] FEMALE_CLOTHESHAIR = new ClothesHairData[]
        {
            new ClothesHairData { Hair = 3},
            new ClothesHairData { Hair = 48},
            new ClothesHairData { Hair = 53},
            new ClothesHairData { Hair = 15}
        };

        public static void AssignPlayerClothesTop(Player player, int slot)
        {
            bool gender = player.GetUserData().Gender;

            if (gender)
            {
                if (slot >= 0 && slot < MALE_CLOTHESTOP.Length)
                {
                    SetPlayerClothesTop(player, MALE_CLOTHESTOP[slot]);
                    return;
                }

                player.SendChatMessage("Esta prenda no existe");
                return;
            }

            else
            {
                if (slot >= 0 && slot < FEMALE_CLOTHESTOP.Length)
                {
                    SetPlayerClothesTop(player, FEMALE_CLOTHESTOP[slot]);
                    return;
                }

                player.SendChatMessage("Esta prenda no existe");
                return;
            }
        }

        public static void AssignPlayerClothesBottom(Player player, int slot)
        {
            bool gender = player.GetUserData().Gender;

            if (gender)
            {
                if (slot >= 0 && slot < MALE_CLOTHESBOTTOM.Length)
                {
                    SetPlayerClothesBottom(player, MALE_CLOTHESBOTTOM[slot]);
                    return;
                }

                player.SendChatMessage("Esta prenda no existe");
                return;
            }
            else
            {
                if (slot >= 0 && slot < FEMALE_CLOTHESBOTTOM.Length)
                {
                    SetPlayerClothesBottom(player, FEMALE_CLOTHESBOTTOM[slot]);
                    return;
                }

                player.SendChatMessage("Esta prenda no existe");
                return;
            }
        }

        public static void AssignPlayerClothesHair(Player player, int slot)
        {
            bool gender = player.GetUserData().Gender;

            if (gender)
            {
                if (slot >= 0 && slot < MALE_CLOTHESHAIR.Length)
                {
                    SetPlayerClothesHair(player, MALE_CLOTHESHAIR[slot]);
                    return;
                }

                player.SendChatMessage("Esta prenda no existe");
                return;
            }
            else
            {
                if (slot >= 0 && slot < FEMALE_CLOTHESHAIR.Length)
                {
                    SetPlayerClothesHair(player, FEMALE_CLOTHESHAIR[slot]);
                    return;
                }

                player.SendChatMessage("Esta prenda no existe");
                return;
            }
        }

        public static void SetPlayerClothesTop(Player player, ClothesTopData clothestop)
        {
            player.SetClothes(COMPONENT_ID_TORSO, clothestop.Torso, 0);
            player.SetClothes(COMPONENT_ID_UNDERSHIRT, clothestop.Undershirt, 0);
            player.SetClothes(COMPONENT_ID_TOP, clothestop.Top, 0);
        }

        private static void SetPlayerClothesBottom(Player player, ClothesBottomData clothesbottom)
        {
            player.SetClothes(COMPONENT_ID_LEGS, clothesbottom.Legs, 0);
            player.SetClothes(COMPONENT_ID_SHOES, clothesbottom.Shoes, 0);
        }

        private static void SetPlayerClothesHair(Player player, ClothesHairData clotheshair)
        {
            player.SetClothes(COMPONENT_ID_HAIR, clotheshair.Hair, 0);
        }

    }
}
