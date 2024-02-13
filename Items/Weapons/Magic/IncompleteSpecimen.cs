using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class IncompleteSpecimen : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Magic;
			Item.width = 35;
			Item.height = 35;
			Item.useTime = 13;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1.3f;
            Item.value = Item.buyPrice(silver: 70);
            Item.rare = 3;
            Item.mana = 4;
            Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<ForgottenEyes>();
            Item.shootSpeed = 23f;
			Item.UseSound = SoundID.Item11;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 2f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 8, 0);
            position += offset;
            return true;
        }


    }
}