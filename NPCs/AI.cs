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
	public class AI : ModNPC
	{
        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Wraith);
            NPC.height = 80;    
            NPC.width = 80;
            NPC.damage = 10;
            NPC.lifeMax = 50;
            NPC.defense = 5;
            NPC.value = 999f;
            NPC.aiStyle = 14;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.9f;
            AIType = 14;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("The rouge ghostly AI. Will always throw out non-sense and misinformation."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // TODO ADD IN GORE
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.Confused, 600);
        }
    }
}