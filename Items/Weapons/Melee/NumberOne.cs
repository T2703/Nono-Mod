using Microsoft.Xna.Framework;
using NonoMod.Buffs;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class NumberOne : ModItem
	{
        // Ichigo Kurosaki lends you his epic majestic sword. 
        // Probably another version of it or something idk go watch Bleach if you want. (I like it)

        public override void SetDefaults()
		{
			Item.damage = 75;
			Item.DamageType = DamageClass.Melee;
			Item.width = 45;
			Item.height = 45;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 10, silver: 10, copper: 10);
            Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<NumberOneEffects>();
            Item.shootSpeed = 20f;
            Item.shootsEveryUse = true;
            Item.UseSound = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/NumberOneSlashSFX")
            {
                Volume = 0.7f,
                PitchVariance = 0.4f,
                MaxInstances = 10,
            };

        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofMight, 30);
            recipe.AddIngredient(ItemID.SoulofNight, 25);
            recipe.AddIngredient(ItemID.SoulofLight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // The true melee effects.
            float adjustedItemScale = player.GetAdjustedItemScale(Item);
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax * 1.5f, adjustedItemScale);
            // Some wack coding but just this make it work for both sides.
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction - 50, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax * 1.5f, adjustedItemScale);
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction + 50, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax * 1.5f, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI);

            // Shoot getsutenyso (idk I forgot how to spell).
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<NumberOneProjectile>(), damage / 2, knockback, player.whoAmI);

            return true;
        }


        public override bool MeleePrefix()
        {
            return true;
        }
    }
}