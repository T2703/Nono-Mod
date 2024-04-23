using Microsoft.Xna.Framework;
using NonoMod.Items;
using NonoMod.Items.Consumables;
using NonoMod.Items.Materials;
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
	public class DemonMan : ModNPC
	{
        public override void SetDefaults()
        {
            NPC.height = 75;    
            NPC.width = 75;
            NPC.damage = 33;
            NPC.lifeMax = 130;
            NPC.defense = 10;
            NPC.value = 1001f;
            NPC.aiStyle = 14;
            NPC.velocity *= 10f;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 1f;
            AIType = 14;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!NPC.downedBoss3)
            {
                return 0f;
            }
            else if (spawnInfo.PlayerSafe)
            {
                return 0f;
            }

            return SpawnCondition.Underworld.Chance * 0.29f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DemonPoints>(), 1, 5, 10));

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A fallen legend that is now doomed to roam the underworld for all eternity because he's already a demon."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // TODO ADD IN GORE
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.OnFire, 500);
        }
    }
}