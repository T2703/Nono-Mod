using Microsoft.Xna.Framework;
using NonoMod.Items.Weapons.Magic;
using NonoMod.Items.Weapons.Melee;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Drops
{
	public class NPCDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.ChaosElemental)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CoffeeAndCream>(), 20, 1, 1));
            }

            // Skull Emoji
            if (npc.type == NPCID.GiantCursedSkull)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UnderTheGraveyard>(), 11, 1, 1));
            }

            if (npc.type == NPCID.Nailhead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AngelThanatos>(), 25, 1, 1));
            }

            if(npc.type == NPCID.Parrot)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StutteringParrot>(), 26, 1, 1));
            }
        }
    }
}