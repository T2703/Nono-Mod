using Microsoft.Xna.Framework;
using NonoMod.Items;
using NonoMod.Items.Consumables;
using NonoMod.Items.Materials;
using NonoMod.Items.Pictures;
using NonoMod.Items.Projectiles;
using NonoMod.Items.Weapons.Magic;
using NonoMod.Items.Weapons.Melee;
using NonoMod.Items.Weapons.Ranged;
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
	public class Senator : ModNPC
	{
        public int timer1 = 0;
        public int timerShoot = 0;
        private int burstCount = 3;
        private int burstInterval = 5;

        public override void SetDefaults()
        {
            NPC.height = 150;    
            NPC.width = 100;
            NPC.damage = 45;
            NPC.lifeMax = 375;
            NPC.defense = 35;
            NPC.value = 2150f;
            NPC.aiStyle = 44;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.Item14;
            NPC.knockBackResist = 0.3f;
            AIType = 44;
        }

        public override void AI()
        {
            if (NPC.life <= NPC.life / 2)
            {
                timer1++;
                NPC.TargetClosest();
                if (timer1 > 90 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    timer1 = 0;
                    timerShoot++;
                    var source = NPC.GetSource_FromAI();
                    Vector2 position = NPC.Center;
                    Vector2 targetPosition = Main.player[NPC.target].Center;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 5f;
                    int type = ModContent.ProjectileType<StarsNStripes>();
                    int damage = NPC.damage; //If the projectile is hostile, the damage passed into NewProjectile will be applied doubled, and quadrupled if expert mode, so keep that in mind when balancing projectiles if you scale it off NPC.damage (which also increases for expert/master)
                    
                    // Shoot bursts at specific intervals
                    if (timerShoot % (burstCount * burstInterval) < burstCount * burstInterval && timerShoot % burstInterval == 0)
                    {
                        Projectile.NewProjectile(source, position, direction * speed, type, damage, 0f, Main.myPlayer);
                    }

                    // Reset timerShoot after completing a burst
                    if (timerShoot >= burstCount * burstInterval)
                    {
                        timerShoot = 0;
                    }
                }
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
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HelicopterGun>(), 19, 1, 1));

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Has played college ball you know."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // TODO ADD IN GORE

            // Death smoke thing.
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Smoke, 0f, 0f, 100, default, 1f);
                dust.velocity *= 0.8f;
                dust.noGravity = true;
            }
        }

    }
}