using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NonoMod.Buffs;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Ranged
{
	public class Doomstick : ModItem
	{
        public float dashVelocity = 18f;
        public int dashDelay = 0;
        public int dashTimer = 0;

        public override void SetDefaults()
		{
			Item.damage = 160;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
            Item.height = 16;
			Item.useTime = 80;
			Item.useAnimation = 80;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 15;
            Item.value = Item.buyPrice(gold: 66, silver: 66, copper: 66);
            Item.rare = 5;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 26f;
            Item.useAmmo = AmmoID.Bullet;
            Item.UseSound = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/SSGShootSFX")
            {
                Volume = 0.8f,
                MaxInstances = 10,
            };
        }


        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 14;
                Item.useAnimation = 14;
                Item.UseSound = SoundID.Item71;
            }
            else
            {
                Item.useTime = 80;
                Item.useAnimation = 80;
                Item.UseSound = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/SSGShootSFX")
                {
                    Volume = 0.8f,
                    MaxInstances = 10,
                };
            }

            return true;
        }

        public override bool RangedPrefix()
        {
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                int hookDMG = 160;
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<DoomstickProjectile>(), hookDMG * 2, knockback, player.whoAmI);
            }
            else
            {
                int numberProjectiles = 5 + Main.rand.Next(3);
                for (int i = 0; i < numberProjectiles; i++)
                {

                    Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(20)), type, damage, knockback, player.whoAmI);

                }

                if (Main.rand.NextFloat() >= 0.30f)
                {
                    Projectile.NewProjectile(source, position, velocity, ProjectileID.InfernoFriendlyBolt, damage, knockback, player.whoAmI);
                }
            }

            return false; 
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.66f;
        }

        public void GrappleDash(Player player)
        {
            Vector2 newVel = player.velocity;

            if (player.direction == 1)
            {
                newVel.X = dashVelocity;
                if (player.position.Y > 0)
                {
                    newVel.Y = -7f;
                }
            }
            else if (player.direction == -1)
            {
                newVel.X = -dashVelocity;
                if (player.position.Y > 0)
                {
                    newVel.Y = -7f;
                }
            }
            player.velocity = newVel;
            player.immune = true;
            player.immuneTime = 30;


            if (dashDelay > 0)
            {
                dashDelay--;
            }

            if (dashTimer > 0)
            {
                dashTimer--;
            }
        }

    }

    internal class DoomstickProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
        }

        public override void SetStaticDefaults()
        {
            // If you wish for your hook projectile to have ONE copy of it PER player, uncomment this section.
            ProjectileID.Sets.SingleGrappleHook[Type] = true;
        }

        // Amethyst Hook is 300, Static Hook is 600
        public override float GrappleRange()
        {
            return 360f;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 1;
        }

        // default is 11, Lunar is 24
        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            Projectile.damage = 0;
            speed = 20f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 20;
        }

        public override void GrappleTargetPoint(Player player, ref float grappleX, ref float grappleY)
        {
            Vector2 dirToPlayer = Projectile.DirectionTo(player.Center);
            float hangDist = 45f;
            grappleX += dirToPlayer.X * hangDist;
            grappleY += dirToPlayer.Y * hangDist;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Doomstick doomstick = new Doomstick();
            Player player = Main.LocalPlayer;
            doomstick.GrappleDash(player);
            //Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position.X, target.position.Y, 0, 0, ModContent.ProjectileType<GrappleBlock>(), Projectile.damage, 0, Projectile.owner);
            //Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position.X, target.position.Y, 0, 0, ProjectileID.DirtiestBlock, Projectile.damage, 0, Projectile.owner);
            target.AddBuff(BuffID.OnFire, 1000);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(BuffID.OnFire, 1000);
        }

    }
}