using Microsoft.Xna.Framework;
using NonoMod.Items;
using NonoMod.Items.Materials;
using NonoMod.Items.Weapons.Melee;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace NonoMod.NPCs
{
	public class V : ModNPC
	{
        public override void SetDefaults()
        {
            NPC.damage = 15;
            NPC.lifeMax = 50;
            NPC.defense = 20;
            NPC.height = 42;
            NPC.width = 42;
            NPC.value = 420f;
            NPC.aiStyle = 3;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.knockBackResist = 0.5f;
            AIType = 3;
        }


        /*public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UilxMatter>(), 2, Main.rand.Next(2, 3), Main.rand.Next(5, 6)));

        }*/

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A fast and tough solider, made as a fodder unit."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.HallowedTorch, 0f, 0f, 10, Color.Pink, 1f);
                dust.velocity *= 1f;
                dust.scale *= 1f;
            }
        }

    }
}