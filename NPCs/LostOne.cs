using Microsoft.Xna.Framework;
using NonoMod.Items;
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
	public class LostOne : ModNPC
	{
        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Wraith);
            NPC.height = 54;    
            NPC.width = 54;
            NPC.damage = 10;
            NPC.lifeMax = 100;
            NPC.defense = 7;
            NPC.value = 650f;
            NPC.aiStyle = 22;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.knockBackResist = 0.6f;
            AIType = 22;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.PlayerSafe)
            {
                return 0f;
            }

            return SpawnCondition.Cavern.Chance * 0.16f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ReplicaOfALegend>(), 8, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Aurora>(), 5, 1, 1));

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Once a brave warrior but, forgotten in time. Now roams endlessly attacking those who he comes across."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Wraith, 0f, 0f, 10, Color.GhostWhite, 1f);
                dust.velocity *= 1f;
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(22, 850);
        }
    }
}