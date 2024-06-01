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
	public class Peecock : ModNPC
	{
        // Great naming and code btw
        public int timer1 = 0;
        public int timer2 = 0;
        private bool isCooldown = false;
        private int cooldownTimer = 0;
        private const int CooldownPeriod = 1000; 
        private const int BarrageDuration = 420; 
        private const int FireInterval = 5;

        public override void SetDefaults()
        {
            NPC.height = 50;    
            NPC.width = 50;
            NPC.damage = 5;
            NPC.lifeMax = 90;
            NPC.defense = 20;
            NPC.value = 1675f;
            NPC.aiStyle = 44;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.Item14;
            NPC.knockBackResist = 0.3f;
            AIType = 44;
        }

        public override void AI()
        {
            if (isCooldown)
            {
                // Cooldown period after barrage
                cooldownTimer++;
                if (cooldownTimer >= CooldownPeriod)
                {
                    isCooldown = false;
                    cooldownTimer = 0;
                    timer1 = 0;
                }
            }
            else
            {
                // Barrage firing mechanism
                timer1++;
                timer2++;

                if (timer1 <= BarrageDuration)
                {
                    if (timer2 >= FireInterval && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        timer2 = 0;
                        var source = NPC.GetSource_FromAI();
                        Vector2 position = NPC.Center;
                        Vector2 targetPosition = Main.player[NPC.target].Center;
                        Vector2 direction = targetPosition - position;
                        direction.Normalize();
                        float speed = 30f;
                        int type = ProjectileID.BulletDeadeye;
                        int damage = NPC.damage;
                        Projectile.NewProjectile(source, position, direction * speed, type, damage, 0f, Main.myPlayer);
                    }
                }
                else
                {
                    // Enter cooldown period after barrage
                    isCooldown = true;
                }
            }

            NPC.TargetClosest();
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
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RedJetstream>(), 23, 5, 10));

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("The best darn pilot around, gets to the LZ on time and has deadly accuracy with his machine gun. Tread carefully."),
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