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
        public float dashVelocity = 25f;
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
                Item.useTime = 8;
                Item.useAnimation = 8;
            }
            else
            {
                Item.useTime = 80;
                Item.useAnimation = 80;
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
            }
            else if (player.direction == -1)
            {
                newVel.X = -dashVelocity;
            }
            player.velocity = newVel;


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
            /*	this.netImportant = true;
				this.name = "Gem Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			*/
            Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
        }

        // Use this hook for hooks that can have multiple hooks mid-flight: Dual Hook, Web Slinger, Fish Hook, Static Hook, Lunar Hook
        public override bool? CanUseGrapple(Player player)
        {
            int hooksOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == Projectile.type)
                {
                    hooksOut++;
                }
            }
            return true;
        }

        // Return true if it is like: Hook, CandyCaneHook, BatHook, GemHooks
        //public override bool? SingleGrappleHook(Player player)
        //{
        //	return true;
        //}


        // Use this to kill oldest hook. For hooks that kill the oldest when shot, not when the newest latches on: Like SkeletronHand
        // You can also change the projectile like: Dual Hook, Lunar Hook
        //public override void UseGrapple(Player player, ref int type)
        //{
        //	int hooksOut = 0;
        //	int oldestHookIndex = -1;
        //	int oldestHookTimeLeft = 100000;
        //	for (int i = 0; i < 1000; i++)
        //	{
        //		if (Main.projectile[i].active && Main.projectile[i].owner == projectile.whoAmI && Main.projectile[i].type == projectile.type)
        //		{
        //			hooksOut++;
        //			if (Main.projectile[i].timeLeft < oldestHookTimeLeft)
        //			{
        //				oldestHookIndex = i;
        //				oldestHookTimeLeft = Main.projectile[i].timeLeft;
        //			}
        //		}
        //	}
        //	if (hooksOut > 1)
        //	{
        //		Main.projectile[oldestHookIndex].Kill();
        //	}
        //}

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
            target.AddBuff(BuffID.OnFire, 1200);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(BuffID.OnFire, 1200);
        }

        /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
            Vector2 center = Projectile.Center;
            Vector2 distToProj = playerCenter - Projectile.Center;
            float projRotation = distToProj.ToRotation() - 1.57f;
            float distance = distToProj.Length();
            while (distance > 30f && !float.IsNaN(distance))
            {
                distToProj.Normalize();                 //get unit vector
                distToProj *= 24f;                      //speed = 24
                center += distToProj;                   //update draw position
                distToProj = playerCenter - center;    //update distance
                distance = distToProj.Length();
                Color drawColor = lightColor;

                //Draw chain
                spriteBatch.Draw(mod.GetTexture("Items/ExampleHookChain"), new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
                    new Rectangle(0, 0, Main.chain30Texture.Width, Main.chain30Texture.Height), drawColor, projRotation,
                    new Vector2(Main.chain30Texture.Width * 0.5f, Main.chain30Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f); 
            }
            return true;
        }*/

    }
}