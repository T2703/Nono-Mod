using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using NonoMod.Items.Weapons.Melee;
using NonoMod.Items.Weapons.Ranged;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Drops
{
	public class ChestLoot : ModSystem
	{
        public override void PostWorldGen()
        {
            // Gold Chests
            int[] itemsToPlaceInChest = { ModContent.ItemType<WritingOnTheWall>(), ModContent.ItemType<GoodTastyChicken>() };
            int itemsToPlaceInChestChoice = 0;

            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];

                if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 1 * 36)
                {
                    if (WorldGen.genRand.NextBool(4))
                    {
                        continue;
                    }

                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {

                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChest[itemsToPlaceInChestChoice]);
                            itemsToPlaceInChestChoice = (itemsToPlaceInChestChoice + 1) % itemsToPlaceInChest.Length;
                            break;
                        }
                    }
                }
            }

            // Brown chests
            /*int[] itemsToPlaceInBrownChest = { ModContent.ItemType<ToyGun>() };
            int itemsToPlaceInBrownChestChoice = 0;

            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];

                if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 1 * 36)
                {
                    if (WorldGen.genRand.NextBool(4))
                    {
                        continue;
                    }

                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {

                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChest[itemsToPlaceInChestChoice]);
                            itemsToPlaceInChestChoice = (itemsToPlaceInChestChoice + 1) % itemsToPlaceInChest.Length;
                            break;
                        }
                    }
                }
            }*/
        }
    }
}