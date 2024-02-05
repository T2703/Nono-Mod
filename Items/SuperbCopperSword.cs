using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items
{
	public class SuperbCopperSword : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Melee;
			Item.width = 45;
			Item.height = 45;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 7;
            Item.value = Item.buyPrice(gold: 3, silver: 50, copper: 50);
            Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shoot = Mod.Find < ModProjectile >("TrueMeleeEffect").Type;

        }

        /*public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddIngredient(ItemID.CopperPickaxe, 1);
            recipe.AddIngredient(ItemID.CopperAxe, 1);
            recipe.AddIngredient(ItemID.MeteoriteBar, 30);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}*/

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // The true melee effects.
            float adjustedItemScale = player.GetAdjustedItemScale(Item);
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax * 2f, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI);

            // Shoot projectile.
            //Projectile.NewProjectile(source, position, velocity, ProjectileID.Volcano, damage, knockback, player.whoAmI);
            Vector2 offset = new Vector2(velocity.X * 1, velocity.Y * 1);
            position += offset;
            Projectile.NewProjectile(source, position, velocity, Mod.Find<ModProjectile>("CopperProjectile").Type, damage, knockback, player.whoAmI);
            Item.shootSpeed = 15f;


            return true;
        }

        public override bool MeleePrefix()
        {
            return true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            //base.MeleeEffects(player, hitbox);
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Copper, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
        }
    }
}