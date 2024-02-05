using Microsoft.Xna.Framework;
using NonoMod.Items;
using NonoMod.Items.Accessories;
using NonoMod.Items.Weapons.Magic;
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
    // My excuse to have a slime enemey
	public class GamingB : ModNPC
	{
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[3];
        }

        public override void SetDefaults()
        {
            NPC.height = 32;    
            NPC.width = 55;
            NPC.damage = 20;
            NPC.lifeMax = 85;
            NPC.defense = 10;
            NPC.value = 1230f;
            NPC.lavaImmune = false;
            NPC.aiStyle = NPCAIStyleID.Slime;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.3f;
            AIType = NPCID.GreenSlime;
            AnimationType = NPCID.GreenSlime;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.PlayerSafe)
            {
                return 0f;
            }

            return SpawnCondition.OverworldNightMonster.Chance * 0.10f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<QuarterCircleFwd>(), 7, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GiftCard>(), 6, 1, 1));
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 20)
            {
                NPC.frameCounter = 0;
            }
            NPC.frame.Y = (int)NPC.frameCounter / 7 * frameHeight;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Interesting critter, it seems to enjoy anything gaming related and thinks it's whole life is a game."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.PinkSlime, 0f, 0f, 100, default, 1f);
                    dust.velocity *= 0.7f;
                    dust.scale *= 1f;
                }
            }
        }
    }
}