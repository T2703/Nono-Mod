using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Steamworks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items
{
	public class Tsurugi : ModItem
	{
        // The name sounds cool has nothing to do with the Japanese sword. 

        public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 7;
            Item.value = Item.buyPrice(gold: 15);
			Item.rare = 5;
			Item.UseSound = SoundID.Item15;
			Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<TsurugiEffect>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item);
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax * 1f, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI);

            float mouseX = Main.MouseWorld.X;
            float mouseY = player.position.Y - 600f; 

			for (int i = 0; i < 3; i++)
			{
                float randomOffsetX = Main.rand.NextFloat(-50f, 50f);
                float posX = mouseX + randomOffsetX;

                float randomOffsetY = Main.rand.NextFloat(-50f, 50f);
                float posY = mouseY + randomOffsetY;

                Projectile.NewProjectile(source, posX, posY, 0f, 45f, Mod.Find<ModProjectile>("TsurugiRain").Type, damage, knockback, player.whoAmI);
            }
           
            return false;
        }


        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpectreBar, 25);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            //base.MeleeEffects(player, hitbox);
            //AddLight(Item.position, 255, 255, 255);
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.DungeonSpirit, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 1.5f;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn2, 50);
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.Frostburn2, 50);
        }
    }
}