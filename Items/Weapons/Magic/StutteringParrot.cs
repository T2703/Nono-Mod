using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class StutteringParrot : ModItem
	{
        // Are you guys going trick or treating?

        public override void SetDefaults()
		{
			Item.damage = 90;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 45;
            Item.useAnimation = 45;
            Item.mana = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 42f;
            Item.value = Item.buyPrice(gold: 6, silver: 90);
            Item.rare = ItemRarityID.Orange;
			Item.autoReuse = false;
			Item.noMelee = true;
            Item.shootSpeed = 16.3f;
            Item.UseSound = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/StutteringParrotSFX")
            {
                Volume = 0.7f,
                MaxInstances = 10,
            };
            Item.shoot = ModContent.ProjectileType<TrickOrTreat>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 8, 0);
            position += offset;
            return true;
        }

    }
}