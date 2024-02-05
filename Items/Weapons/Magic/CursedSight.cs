using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class CursedSight : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 10;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3;
            Item.value = Item.buyPrice(gold: 4, silver: 50);
            Item.rare = 3;
            Item.mana = 10;
            Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ProjectileID.GreenLaser;
            Item.shootSpeed = 20f;
			Item.UseSound = SoundID.Item33;
            Item.reuseDelay = 14;
        }

        /*public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 2f);
        }*/

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 8, 0);
            position += offset;
            return true;
        }


    }
}