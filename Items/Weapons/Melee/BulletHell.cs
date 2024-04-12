using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class BulletHell : ModItem
	{
        // Gun sword lol

        public override void SetDefaults()
		{
			Item.damage = 101;
			Item.DamageType = DamageClass.Melee;
            Item.scale = 1.5f;
			Item.width = 45;
			Item.height = 45;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 41, silver: 70, copper: 38);
            Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item15;
            Item.autoReuse = true;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 0, default, 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 1f;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var source = player.GetSource_ItemUse(Item);
            Vector2 targetPOS = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = targetPOS.Y;
            Vector2 position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
            Vector2 heading = targetPOS - position;

            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }

            for (int  i = 0; i < 3; i++)
            {
                position.Y -= 100 * i;
                heading.Normalize();
                heading *= 50;
                heading.Y += Main.rand.Next(-41, 43) * 0.03f;
                Projectile.NewProjectile(source, position, heading, ProjectileID.BulletHighVelocity, Item.damage / 2, Item.knockBack, player.whoAmI, 0f, ceilingLimit);
            }
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            var source = player.GetSource_ItemUse(Item);
            Vector2 targetPOS = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = targetPOS.Y;
            Vector2 position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
            Vector2 heading = targetPOS - position;

            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }

            for (int i = 0; i < 3; i++)
            {
                position.Y -= 100 * i;
                heading.Normalize();
                heading *= 50;
                heading.Y += Main.rand.Next(-41, 43) * 0.03f;
                Projectile.NewProjectile(source, position, heading, ProjectileID.BulletHighVelocity, Item.damage / 2, Item.knockBack, player.whoAmI, 0f, ceilingLimit);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.EndlessMusketPouch, 1);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}