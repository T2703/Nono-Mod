using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class PriestExecution : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 17;
            Item.useAnimation = 17;
            Item.mana = 7;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3f;
            Item.value = Item.buyPrice(gold: 2, silver: 50);
            Item.rare = 3;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shootSpeed = 16f;
			Item.UseSound = SoundID.Item20;
            Item.shoot = ModContent.ProjectileType<PriestExecutionThrow>();
        }

    }
}