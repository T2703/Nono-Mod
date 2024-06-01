using Microsoft.Xna.Framework;
using NonoMod.Items;
using NonoMod.Items.Consumables;
using NonoMod.Items.Materials;
using NonoMod.Items.Pictures;
using NonoMod.Items.Projectiles;
using NonoMod.Items.Weapons.Magic;
using NonoMod.Items.Weapons.Melee;
using Steamworks;
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
	public class Jetstream : ModNPC
	{
        public int timer2;

        public override void SetDefaults()
        {
            NPC.height = 100;    
            NPC.width = 100;
            NPC.damage = 40;
            NPC.lifeMax = 150;
            NPC.defense = 15;
            NPC.value = 1500f;
            NPC.aiStyle = 22;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.8f;
            AIType = 22;
        }

        public override void AI()
        {
            timer2++;
            NPC.TargetClosest();

            if (timer2 > 105 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                timer2 = 0;
                var source = NPC.GetSource_FromAI();
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 10f;
                int type = ModContent.ProjectileType<SamSlash>();
                int damage = NPC.damage; //If the projectile is hostile, the damage passed into NewProjectile will be applied doubled, and quadrupled if expert mode, so keep that in mind when balancing projectiles if you scale it off NPC.damage (which also increases for expert/master)
                Projectile.NewProjectile(source, position, direction * speed, type, damage, 0f, Main.myPlayer);
            }
           

        }

        /*public override float SpawnChance(NPCSpawnInfo spawnInfo)
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
        }*/

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RedJetstream>(), 23, 1, 1));

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Brazilian samurai, a really skilled one too. Also, loves to smile."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // TODO ADD IN GORE
        }

    }
}