using Microsoft.Xna.Framework;
using NonoMod.Items;
using NonoMod.Items.Accessories;
using NonoMod.Items.Materials;
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
    // Another slime enemy but it's Gudako :0
	public class SmolGudako : ModNPC
	{

        public override void SetDefaults()
        {
            NPC.height = 32;    
            NPC.width = 32;
            NPC.damage = 32;
            NPC.lifeMax = 69;
            NPC.defense = 8;
            NPC.value = 1500f;
            NPC.lavaImmune = true;
            NPC.aiStyle = NPCAIStyleID.Slime;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.2f;
            AIType = NPCID.YellowSlime;
            AnimationType = NPCID.GreenSlime;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.PlayerSafe)
            {
                return 0f;
            }

            return SpawnCondition.Underworld.Chance * 0.35f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FaithQuartz>(), 2, Main.rand.Next(3, 5), Main.rand.Next(6, 9)));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PriestExecution>(), 42, 1, 1));
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Gudako, a small head apart of that person and spawned from her. These heads show crazy behavior and are unhinged with a crippling addiction to gacha."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Blood, 0f, 0f, 100, default, 1f);
                    dust.velocity *= 1.1f;
                    dust.scale *= 0.9f;
                }
            }
        }
    }
}