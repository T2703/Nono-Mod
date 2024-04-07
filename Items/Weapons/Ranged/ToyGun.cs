using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Ranged
{
	public class ToyGun : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 5;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 10;
            Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.5f;
            Item.value = Item.buyPrice(silver: 40, copper: 1);
            Item.rare = 3;
			Item.autoReuse = false;
			Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<ToyBullet>();
            Item.shootSpeed = 20f;
			Item.UseSound = SoundID.Item11;
        }

    }
}