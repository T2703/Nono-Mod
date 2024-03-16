using Microsoft.Xna.Framework;
using NonoMod.Items;
using NonoMod.Items.Consumables;
using NonoMod.Items.Pictures;
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
	public class SillyBeer : ModNPC
	{
        public override void SetDefaults()
        {
            NPC.height = 50;    
            NPC.width = 37;
            NPC.damage = 21;
            NPC.lifeMax = 45;
            NPC.defense = 5;
            NPC.value = 400f;
            NPC.aiStyle = 14;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.Shatter;
            NPC.knockBackResist = 0.3f;
            AIType = 14;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.PlayerSafe)
            {
                return 0f;
            }

            return SpawnCondition.Cavern.Chance * 0.30f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrystalBeer>(), 3, 1, 1));

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A strange beer that wanders around the dark caves looking for it's next customer."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // TODO ADD IN GORE
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Wraith, 0f, 0f, 10, Color.GhostWhite, 1f);
                dust.velocity *= 1f;
            }
        }
    }
}